#!/bin/bash

# Defines some colors
NoColor="\033[0m"
Green="\033[0;32m"
Red="\033[0;31m"

# Root privileges are required for the installation, if the current user is not root, then an error message is returned
CurrentUser=$(whoami)
if [ $CurrentUser != "root" ]; then
    >&2 echo -e "${Red}The installation process requires root privileges.${NoColor}"
    exit 1
fi

# This installation script only supports Ubuntu 14.04 and Ubuntu 16.04, so the distribution is checked, if it is neither of them, then an error message is returned
UbuntuCodeName=$(cat /etc/lsb-release | grep -Po 'DISTRIB_CODENAME=\K.*')
if [ $UbuntuCodeName != "trusty" ] && [ $UbuntuCodeName != "xenial" ]; then
    >&2 echo -e "${Red}Only Ubuntu 14.04 and 16.04 are supported by this installation script.${NoColor}"
    exit 1
fi

# Removes older installations of .NET Core
IsPackageInstalled() {
    dpkg -l $1 &> /dev/null
    if [ $? = 1 ]; then
        return 1
    else
        return 0
    fi
}
UninstallPackages() {
    for package in "$@"
    do
        if IsPackageInstalled $package; then
            apt-get -y purge $package &> /dev/null
            if [ "$?" -ne 0 ]; then
                >&2 echo -e "${Red}Failed to remove package $package.${NoColor}"
                exit 1
            fi
        fi
    done
}
if IsPackageInstalled "dotnet-host" || IsPackageInstalled "dotnet-dev" || IsPackageInstalled "dotnet"; then
    echo "Removing older installations of .NET Core..."
    UninstallPackages "dotnet-host" "dotnet-dev" "dotnet"
fi

# Adds the apt-get feed for .NET Core to the system
echo "Adding .NET Core apt-get feed..."
echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet/ $UbuntuCodeName main" > /etc/apt/sources.list.d/dotnetdev.list
apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893 &> /dev/null

# Installs .NET on the system
echo "Installing .NET Core..."
apt-get update &> /dev/null
apt-get -y install dotnet-dev-1.0.0-preview2-003121 &> /dev/null