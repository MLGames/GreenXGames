
########### Python 3.6 #############
import http.client, urllib.request, urllib.parse, urllib.error, base64, json

###############################################
#### Update or verify the following values. ###
###############################################

# Replace the subscription_key string value with your valid subscription key.
subscription_key = 'e4607df4e4a94416b1986229bceec8af'

# Replace or verify the region.



uri_base = 'westcentralus.api.cognitive.microsoft.com'

headers = {
    # Request headers.
    'Content-Type': 'application/json',
    'Ocp-Apim-Subscription-Key': subscription_key,
}

params = urllib.parse.urlencode({
    # Request parameters. All of them are optional.
    'visualFeatures': 'Categories,Description,Color',
    'language': 'en',
})


body = "{'url':'https://c8.alamy.com/comp/BDR0JF/an-overflowing-trash-can-is-seen-on-the-streets-of-the-chelsea-neighborhood-BDR0JF.jpg'}"

try:
    # Execute the REST API call and get the response.
    conn = http.client.HTTPSConnection('westcentralus.api.cognitive.microsoft.com')
    conn.request("POST", "/vision/v1.0/analyze?%s" % params, body, headers)
    response = conn.getresponse()
    data = response.read()

    # 'data' contains the JSON data. The following formats the JSON data for display.
    parsed = json.loads(data)
    d=parsed
    tags=(d['description']['tags'])
    
 
    coinValue = 0
    trashA="food"
    if(any(trashA in x for x in tags)==True):
        coinValue=coinValue+10
        
    trashB="drinks"
    if(any(trashB in x for x in tags)==True):
        coinValue=coinValue+30
        
    trashC="bottle"
    if(any(trashC in x for x in tags)==True):
        coinValue=coinValue+50   
        
    trashD="plant"
    if(any(trashD in x for x in tags)==True):
        coinValue=coinValue+5 
        
    trashD="paper"
    if(any(trashD in x for x in tags)==True):
        coinValue=coinValue+20 
    
    print ("Response:")
    print (json.dumps(parsed, sort_keys=True, indent=2))
   
    print ("coinValue:"+str(coinValue))
    conn.close()

except Exception as e:
    print('Error:')
    print(e)
