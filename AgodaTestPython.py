import requests 
from datetime import datetime
def callAPIPulls(owner,repo,type):
    if(type == 'pull request'):
        print(f"Repsoity {owner}/{repo} top 10 {type} are:")
        pTitle = "PR-"
        apiType = "pulls"
    elif(type  =="issues"):
        print(f"Repsoity {owner}/{repo} top 10 {type} are:")
        apiType = "issues"
        pTitle = "#"
    headers = {"Authorization":"Bearer e4266e0b3a25ff66a5f7c187a3286eeccdec328b",
                'content-type': 'application/json'}
    params  = {"per_page":1 ,"page":1,"state":"open"}

    query_url = f"https://api.github.com/repos/{owner}/{repo}/{apiType}"
    response = requests.get(query_url,headers= headers,params=params)
    res  = response.json()
    #print(res)
    for json  in res:
        title =  pTitle+str(json['number']) + " "+ json["title"]
        created = "Created by "+str(json['user']['login']) + " "+ str(datetime.strptime(json["created_at"], '%Y-%m-%dT%H:%M:%SZ'))
        state = f"{apiType} is " +json["state"]
        print(title)
        print(created)
        print(state)
        print()

print("Enter the reposity name (format:owner/reposity)")
ownRepos = input()
print("Enter the information type (pull requests,issues)")
inType = input()
if inType.lower() == 'pull-requests':
    own,rep = ownRepos.split("/")
    callAPIPulls(own,rep,"pull request")
elif  inType.lower() == 'issues':
    own,rep = ownRepos.split("/")
    callAPIPulls(own,rep,"issues")

