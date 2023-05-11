Create Database ExpenseTracker
use ExpenseTracker

Create Table Expense
(
Title varchar(50) primary key,
Descrip varchar(100),
TransactionDate date,
Amount decimal
)

select * from Expense 