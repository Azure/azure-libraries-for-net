#############################################
# Define colored output func
function title {
    LGREEN='\033[1;32m'
    CLEAR='\033[0m'

    echo -e ${LGREEN}$1${CLEAR}
}

#############################################

curl -L https://a01tools.blob.core.windows.net/droid/latest/linux/a01droid \
     -o ci/app/a01droid
chmod +x ci/app/a01droid

curl -L https://a01tools.blob.core.windows.net/droid/latest/linux/a01dispatcher \
     -o ci/app/a01dispatcher
chmod +x ci/app/a01dispatcher

title 'Generating tasks list'


title 'Building docker image'
image=azuresdk-a01-droid:net-$TRAVIS_BUILD_NUMBER
docker build -t $image -f ci/Dockerfile .

title 'Pushing docker image'
image=azuresdk-a01-droid:net-$TRAVIS_BUILD_NUMBER
docker login azureclidev.azurecr.io -u $AZURESDKDEV_ACR_SP_USERNAME -p $AZURESDK_ACR_SP_PASSWORD
docker tag azuresdk-a01-droid:net-$TRAVIS_BUILD_NUMBER azureclidev.azurecr.io/azuresdk-a01-droid:net-$TRAVIS_BUILD_NUMBER
docker tag azuresdk-a01-droid:net-$TRAVIS_BUILD_NUMBER azureclidev.azurecr.io/azuresdk-a01-droid:net-latest
docker push azureclidev.azurecr.io/azuresdk-a01-droid:net-$TRAVIS_BUILD_NUMBER
docker push azureclidev.azurecr.io/azuresdk-a01-droid:net-latest
