# Test_IndeedIdWalletAPI - test task for IndeedId
ASP.NET Core WebAPI implementing user's wallet. Actual currencies and their rates should be requested from any public currency WebAPI

Implemented functions:

1) Get User's wallets state:

GET {host}/api/wallet?userId=[userId]

Request
- userId - Required. 32 chars GUID. If User's Id is not found, programm creates new User

Response (example) - application/json
{
    "isSuccess": true,
    "messages": [],
    "result": {
        "userId": "e35efc7e-375d-4bfc-b655-841883466e9c",
        "wallets": [
            {
                "currency": "RUB",
                "amount": 79
            }
        ]
    }
}

2) Change wallet balance (add/withdraw wallet's money)

POST {host}/api/wallet

Request - application/json

{
	"userId" : "e35efc7e-375d-4bfc-b655-841883466e9c",
	"wallet" : {
		"currency" : "EUR",
		"Amount" : -1
	}
}

Response - application/json

{
    "isSuccess": true,
    "messages": [],
    "result": {
        "userId": "e35efc7e-375d-4bfc-b655-841883466e9c",
        "wallets": [
            {
                "currency": "EUR",
                "amount": 0.4217931485999997
            }
        ]
    }
}

Note: filling/withdraw operation is determined with value of amount. Positive value means filling, negative one - withdraw.

3) Convert money from one currency to another.

POST {host}/api/wallet/convert

Request - application/json

{
	"userId" : "e35efc7e-375d-4bfc-b655-841883466e9c",
	"baseCurrency" : "RUB",
	"targetCurrency" : "EUR",
	"amount": 120
}

Response - application/json

{
    "isSuccess": true,
    "messages": [],
    "result": {
        "userId": "e35efc7e-375d-4bfc-b655-841883466e9c",
        "wallets": [
            {
                "currency": "RUB",
                "amount": 79
            },
            {
                "currency": "EUR",
                "amount": 1.4217931485999997
            }
        ]
    }
}
