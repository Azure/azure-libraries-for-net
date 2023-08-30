const args = require('yargs').argv;
const os = require('os');
const fs = require('fs');
const path = require('path');

function credcheck(dir) {
    console.log('Path: ' + dir);

    const redactDict = new Map();
    // storage account keys
    redactDict.set(/\\"keyName\\":\s*\\"key1\\",[\\r\\n]*\s*\\"value\\":\s*\\"(.*?)\\"/g, '\\"keyName\\": \\"key1\\",\\"value\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"keyName\\":\s*\\"key2\\",[\\r\\n]*\s*\\"value\\":\s*\\"(.*?)\\"/g, '\\"keyName\\": \\"key2\\",\\"value\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/;AccountKey=(.*?)(;|\\")/g, ';AccountKey=MGMT_PLACEHOLDER$2');
    redactDict.set(/\\"primaryMasterKey\\": \\"(.*?)\\"/g, '\\"primaryMasterKey\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"primaryReadonlyMasterKey\\": \\"(.*?)\\"/g, '\\"primaryReadonlyMasterKey\\": \\"MGMT_PLACEHOLDER\\"');	
    redactDict.set(/\\"secondaryMasterKey\\": \\"(.*?)\\"/g, '\\"secondaryMasterKey\\":\\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"secondaryReadonlyMasterKey\\": \\"(.*?)\\"/g, '\\"secondaryReadonlyMasterKey\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/;SharedAccessKey=(.*?)(;|\\")/g, ';SharedAccessKey=MGMT_PLACEHOLDER$2');
    redactDict.set(/\\"primaryKey\\": \\"(.*?)\\"/g, '\\"primaryKey\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"secondaryKey\\": \\"(.*?)\\"/g, '\\"secondaryKey\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"adminPassword\\": \\"(.*?)\\"/g, '\\"adminPassword\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"administratorLoginPassword\\": \\"(.*?)\\"/g, '\\"administratorLoginPassword\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"password\\": \\"(.*?)\\"/g, '\\"password\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"connectionString\\": \\"(.*?)\\"/g, '\\"connectionString\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"accessSAS\\": \\"(.*?)\\"/g, '\\"accessSAS\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"storageKey\\": \\"(.*?)\\"/g, '\\"storageKey\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"accessKey\\": \\"(.*?)\\"/g, '\\"accessKey\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"hubDatabasePassword\\": \\"(.*?)\\"/g, '\\"hubDatabasePassword\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"storageAccountKey\\": \\"(.*?)\\"/g, '\\"storageAccountKey\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"adminUserPassword\\": \\"(.*?)\\"/g, '\\"adminUserPassword\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/\\"permissions\\":\s*\\"Full\\",[\\r\\n]*\s*\\"value\\":\s*\\"(.*?)\\"/g, '\\"keyName\\": \\"key1\\",\\"value\\": \\"MGMT_PLACEHOLDER\\"');
    redactDict.set(/userPWD=\\"(.*?)\\"/g, 'userPWD=\\"MGMT_PLACEHOLDER\\"');
	
    credcheckRecursive(dir, redactDict);
}

function credcheckRecursive(dir, redactDict) {
    if (fs.existsSync(dir)) {
        fs.readdirSync(dir).forEach(function(file, index) {
            const curPath = path.join(dir, file);
            if (fs.lstatSync(curPath).isDirectory()) {
                // recurse
                credcheckRecursive(curPath, redactDict);
            } else {
                if (curPath.endsWith('.json')) {
                    const content = fs.readFileSync(curPath).toString('utf8');
                    var redactedContent = content;
                    for (const [key, value] of redactDict.entries()) {
                        redactedContent = redactedContent.replace(key, value);
                    }
                    if (redactedContent !== content) {
                        console.log('File redacted: ' + curPath);

                        fs.writeFileSync(curPath, redactedContent);
                    }
                }
            }
        });
    }
}

const dir = args['path']

credcheck(dir);
