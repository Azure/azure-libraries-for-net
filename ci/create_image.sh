#############################################
# Define colored output func
function title {
    LGREEN='\033[1;32m'
    CLEAR='\033[0m'

    echo -e ${LGREEN}$1${CLEAR}
}

#############################################

title 'Generating tasks list'
./ci/get_tasks_list.sh

title 'Building docker image'
image=azuresdk-net:net-$TRAVIS_BUILD_NUMBER
docker build -t $image -f ci/Dockerfile .

title 'Pushing docker image'
docker login azureclidev.azurecr.io -u $AZURESDKDEV_ACR_SP_USERNAME -p $AZURESDK_ACR_SP_PASSWORD
docker tag azuresdk-net:net-$TRAVIS_BUILD_NUMBER azureclidev.azurecr.io/azuresdk-net:net-$TRAVIS_BUILD_NUMBER
docker tag azuresdk-net:net-$TRAVIS_BUILD_NUMBER azureclidev.azurecr.io/azuresdk-net:net-latest
docker push azureclidev.azurecr.io/azuresdk-net:net-$TRAVIS_BUILD_NUMBER
docker push azureclidev.azurecr.io/azuresdk-net:net-latest
