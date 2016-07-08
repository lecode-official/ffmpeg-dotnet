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

# Downlods the sources for FFmpeg
echo "Downloading FFmpeg sources..."
curl --remote-name http://ffmpeg.org/releases/ffmpeg-3.1.1.tar.bz2 &> /dev/null
if [ $? != 0 ]; then
    echo -e "${Red}The sources for FFmpeg could not be downloaded.${NoColor}"
    exit 1
fi

# Extracts the FFmpeg sources
echo "Extracting the FFmpeg sources..."
tar jxf ffmpeg-3.1.1.tar.bz2 &> /dev/null
if [ $? != 0 ]; then
    echo -e "${Red}The sources for FFmpeg could not be extracted.${NoColor}"
    exit 1
fi

# NASM is needed for the build to work, so it is installed
echo "Installing NASM, which is needed for building FFmpeg..."
apt-get update &> /dev/null
apt-get -y install nasm &> /dev/null

# Configures the the build process to generate shared objects instead of static objects
echo "Configuring build process..."
cd ffmpeg-3.1.1/
./configure --enable-shared &> /dev/null
if [ $? != 0 ]; then
    echo -e "${Red}The build process could not be configured.${NoColor}"
    exit 1
fi

# Starts the build process
echo "Building FFmpeg..."
make &> /dev/null
if [ $? != 0 ]; then
    echo -e "${Red}The build process was unsuccesful.${NoColor}"
    exit 1
fi

# Installs FFmpeg
echo "Installing FFmpeg..."
make install &> /dev/null
if [ $? != 0 ]; then
    echo -e "${Red}FFmpeg could not be installed.${NoColor}"
    exit 1
fi

# Adds the installation path to the ld.so.config, which may be missing on some installations
CanLoadSharedObjects=$(cat /etc/ld.so.conf | grep -c 'include /usr/local/lib/')
if [ $CanLoadSharedObjects == "0" ]; then
    echo "Adding the FFmpeg libraries to /etc/ld.so.conf"
    echo "include /usr/local/lib/" >> /etc/ld.so.conf
    ldconfig
fi

# Prints out a success message and exits the installation script
echo -e "${Green}The installation was completed successfully.${NoColor}"
exit 0