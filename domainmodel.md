# Domain Model

## User Stories

```
As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```

| Class | Method/Attribute | Scenario | Output |
| Bank | CreateAccount(guid customerID) | Method to create an account with a customerID | void |
| Bank | GetAccount(guid customerID, guid bankID) | Method to get an account given a customerID and a Bankaccount | BankAccount |
| Bank | GetMyAccounts(guid customerID) | Method that returns all accounts given a Customer | List<BankAccount> |
| BankAccount | Deposit(decimal amount) | Method to Deposit money into an account | void |
| BankAccount | Withdraw(decimal amount) | Method to Withdraw money from an account | void |
| BankAccount | GenerateBankStatement() | Method that generates a bank statement | string |