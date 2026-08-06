function solve(obj, inputArr) {
    let browser = {};

    for (const key in obj) {
        browser[key] = obj[key];
    }

    inputArr.forEach(action => {
        let [actionType, tabName] = action.split(" ");

        if (actionType === 'Close') {

            let index = browser["Open Tabs"].indexOf(tabName);

            if (index !== -1) {
                browser["Recently Closed"].push(browser["Open Tabs"].splice(index, 1)[0]);
                browser["Browser Logs"].push(action)
            }
        } else if (actionType === 'Open') {
            browser['Open Tabs'].push(tabName)
            browser["Browser Logs"].push(action)
        } else if (action === 'Clear History and Cache') {
            browser['Open Tabs'] = []
            browser["Browser Logs"] = []
            browser["Recently Closed"] = []
        }
    });
    console.log(browser[`Browser Name`])
    console.log(`Open Tabs: ${browser['Open Tabs'].join(', ')}`)
    console.log(`Recently Closed: ${browser['Recently Closed'].join(', ')}`)
    console.log(`Browser Logs: ${browser['Browser Logs'].join(', ')}`)
}
solve({
    "Browser Name": "Google Chrome",
    "Open Tabs": ["Facebook", "YouTube", "Google Translate"],
    "Recently Closed": ["Yahoo", "Gmail"],
    "Browser Logs": ["Open YouTube", "Open Yahoo", "Open Google Translate", "Close Yahoo", "Open Gmail", "Close Gmail", "Open Facebook"]
},
    ["Close Facebook", "Open StackOverFlow", "Open Google"]
)
solve({
    "Browser Name": "Mozilla Firefox",
    "Open Tabs": ["YouTube"],
    "Recently Closed": ["Gmail", "Dropbox"],
    "Browser Logs": ["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]
},
    ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
)