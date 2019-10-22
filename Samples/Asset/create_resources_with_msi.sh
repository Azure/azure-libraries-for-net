#!/bin/bash

/usr/bin/yes | sudo apt-get update
/usr/bin/yes | sudo apt install python-pip
/usr/bin/yes | sudo pip install --upgrade pip
sudo pip install azure-cli
az login --identity -u $1
az storage account create -n $2 -g $3 -l $4 --sku Premium_LRS
