#!/bin/bash
set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"

echo $rootdir

sampleTestPath=/azure-libraries-for-net/Tests/Samples.Tests/
fluentTestPath=/azure-libraries-for-net/Tests/Fluent.Tests/

cd $rootdir/Tests/Samples.Tests/

dotnet test -t --no-build > $rootdir/ci/tasklist

echo "[" > $rootdir/ci/app/test_index
while read line; do
    testcase="$( echo "$line" | cut -d '=' -f 1 )"
    if [[ $testcase == Samples* ]] ; then
        testname="$(echo "$testcase" | rev | cut -d'.' -f1 | rev)"
        recordpath="$(echo "$testcase" | rev | cut -d'.' -f2-7 | rev)"
        sed -e "s;%testcase%;${testcase};g" -e "s|%testpath%|${sampleTestPath}|g" -e "s|%recordpath%|${recordpath}|g" -e "s|%testname%|${testname}|g" $rootdir/ci/task_template > $rootdir/ci/file.out
        task=$(cat $rootdir/ci/file.out)
        echo $task, >> $rootdir/ci/app/test_index
    fi
done < $rootdir/ci/tasklist

cd $rootdir/Tests/Fluent.Tests/

dotnet test -t --no-build > $rootdir/ci/tasklist

while read line; do
    testcase="$( echo "$line" | cut -d '=' -f 1 )"
    if [[ $testcase == Fluent* ]] ; then
        testname="$(echo "$testcase" | rev | cut -d'.' -f1 | rev)"
        recordpath="$(echo "$testcase" | rev | cut -d'.' -f2-7 | rev)"
        sed -e "s/%testcase%/${testcase}/g" -e "s|%testpath%|${fluentTestPath}|g" -e "s|%recordpath%|${recordpath}|g" -e "s|%testname%|${testname}|g" $rootdir/ci/task_template > $rootdir/ci/file.out
        task=$(cat $rootdir/ci/file.out)
        echo $task, >> $rootdir/ci/app/test_index
    fi
done < $rootdir/ci/tasklist

#sed -i '$ s|.$||' ./app/test_index

truncate -s-2 $rootdir/ci/app/test_index

#sed -i '$! { P; D; }; s|.$||' ./app/test_index

echo "]" >> $rootdir/ci/app/test_index