<# 
.SYNOPSIS
    Using Azure AD App Proxy to expose an internal API protected by AAD and using Powershell to access that API via an AAD service principal

.DESCRIPTION 
 
.NOTES 

.COMPONENT 
   

.LINK 
    https://learn.microsoft.com/en-us/azure/active-directory/app-proxy/application-proxy-secure-api-access
 
.Parameter ParameterName 
#>

## Preparations
# 1. Create an AD App proxy App https://learn.microsoft.com/en-us/azure/active-directory/app-proxy/application-proxy-secure-api-access
# 2. Create a Service Principal for use by this script
# 3. Authorize a user for using the service principle

## Getting Access to an protected API

# Getting everything for requesting the access token
$Appid = "<App/Client ID>"
$secret = "<Secret>"
$username = "<user name>"
$password = "<password>"
$APIresourceurl = "<Url of the API>"
$APIendpointurl = "<API endpoint>"

# Creating the body for the request
$body = "grant_type=password" +`
"&client_id=$Appid" +`
"&username=$username" +`
"&password=$password" +`
"&resource=$APIresourceurl" +`
"&client_secret=$secret" +`
"&scope=user_impersonation"

# Getting the access token from Azure AD
$req = Invoke-RestMethod -Method Post -Uri $APIresourceurl -Body $body
$token = $req.access_token

# building the header for the request to the API
$headers = @{
    Authorization="Bearer $token"
}

# calling the API with the header and the right access token
$result = Invoke-WebRequest -Uri $APIendpointurl -Header $headers -Method GET -ContentType "application/json"

# Printing out the API response
$result.Content
