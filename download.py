import requests
import json
import os.path
import codecs

def download(submissionId) :
	res = requests.post("http://codeforces.com/data/submitSource", data={'submissionId':submissionId});
	
	return json.loads(res.text)['source'].replace("\r","")

def getSubmissions(user):
	i = 1
	c = 50
	s = [];
	while True:
		query = {'count':c, 'from':i, 'handle':user}
		res = requests.get("http://codeforces.com/api/user.status", params = query)
		res = json.loads(res.text)['result']
		s += res;
		if len(res) < c:
			break
		i += c	
	
	return [{
		'id':x['id'], 
		'problem':x['problem']['name'], 
		'contestId':str(x['problem']['contestId']),
		'problemId':str(x['problem']['index']) 
		} for x in s if x['verdict'] == "OK" ]

def main(user):
	for submission in getSubmissions(user):
		filn = 'p'+submission['contestId'] + submission['problemId']+'-'+str(submission['id'])+'.cs'
		if not os.path.isfile(filn):
			fp=codecs.open(filn, 'w', 'utf-8-sig')
			fp.write('// '+submission['problem']+'\n')
			fp.write('// http://codeforces.com/problemset/problem/'+submission['contestId']+'/'+submission['problemId']+'\n')
			fp.write(download(submission['id']))
			fp.close()
		
if __name__ == "__main__":
    main('encse')