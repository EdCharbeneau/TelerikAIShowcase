namespace AIShowcase.WebApp.Components.Pages.Assistants.Grid;
using System;
using System.Collections.Generic;

public class CustomerService
	{
		public List<CustomerDto> GetData()
		{
			var data = new List<CustomerDto>()
			{
				new CustomerDto()
				{
					Id = 1,
					CustomerName = "Jytte Petersen",
					Amount = -245.45m,
					Fee = 6.42m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 11, 9, 4, 5, 48, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 2,
					CustomerName = "Laurence Lebihan",
					Amount = -1083.26m,
					Fee = 11.37m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 11, 18, 8, 44, 3, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 3,
					CustomerName = "Daniel Tonini",
					Amount = 554.54m,
					Fee = 7.84m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 1, 16, 3, 37, 26, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 4,
					CustomerName = "Martín Sommer",
					Amount = -341.19m,
					Fee = 10.98m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 9, 22, 5, 26, 45, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 5,
					CustomerName = "Antonio Moreno",
					Amount = 263.93m,
					Fee = 10.72m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 6, 16, 10, 49, 6, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 6,
					CustomerName = "Hanna Moos",
					Amount = 1357.55m,
					Fee = 4.74m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 1, 24, 1, 45, 33, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 7,
					CustomerName = "Paula Parente",
					Amount = -570.83m,
					Fee = 6.27m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 5, 3, 8, 18, 13, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 8,
					CustomerName = "Liu Wong",
					Amount = 543.23m,
					Fee = 11.11m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 9, 6, 4, 37, 24, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 9,
					CustomerName = "André Fonseca",
					Amount = 677.5m,
					Fee = 5.24m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 8, 2, 9, 49, 52, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 10,
					CustomerName = "Marie Bertrand",
					Amount = -1233.2m,
					Fee = 3.76m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 4, 16, 5, 5, 50, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 11,
					CustomerName = "José Pedro Freyre",
					Amount = -699.8m,
					Fee = 7.01m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 1, 22, 5, 17, 24, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 12,
					CustomerName = "Alexander Feuer",
					Amount = 1806.9m,
					Fee = 3.24m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 5, 10, 4, 19, 21, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 13,
					CustomerName = "Maria Anders",
					Amount = -1463.27m,
					Fee = 5.48m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 11, 23, 10, 54, 26, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 14,
					CustomerName = "Frédérique Citeaux",
					Amount = 58.55m,
					Fee = 5.03m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 12, 14, 3, 40, 36, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 15,
					CustomerName = "Aria Cruz",
					Amount = 111.6m,
					Fee = 0.08m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 5, 20, 4, 30, 14, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 16,
					CustomerName = "Bernardo Batista",
					Amount = -851.56m,
					Fee = 11.68m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 2, 4, 9, 18, 26, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 17,
					CustomerName = "Roland Mendel",
					Amount = -1505.18m,
					Fee = 2.86m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 10, 10, 5, 40, 51, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 18,
					CustomerName = "Yvonne Moncada",
					Amount = 970.36m,
					Fee = 10.62m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 11, 15, 9, 8, 17, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 19,
					CustomerName = "Lino Rodriguez",
					Amount = -1789.69m,
					Fee = 2.95m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 2, 4, 1, 52, 58, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 20,
					CustomerName = "Aria Cruz",
					Amount = 829.52m,
					Fee = 10.36m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 12, 8, 3, 23, 4, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 21,
					CustomerName = "Sophia Turner",
					Amount = 1147.28m,
					Fee = 3.53m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 7, 23, 4, 16, 55, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 22,
					CustomerName = "Georg Pipps",
					Amount = -901.62m,
					Fee = 11m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 7, 8, 3, 58, 7, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 23,
					CustomerName = "Georg Pipps",
					Amount = 125.4m,
					Fee = 6.66m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 6, 26, 7, 18, 23, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 24,
					CustomerName = "Lúcia Carvalho",
					Amount = 1567.78m,
					Fee = 0.13m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 6, 20, 10, 11, 7, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 25,
					CustomerName = "André Fonseca",
					Amount = -1673.23m,
					Fee = 0.81m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 10, 25, 4, 14, 47, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 26,
					CustomerName = "Elizabeth Lincoln",
					Amount = 1476.44m,
					Fee = 2.89m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 9, 26, 1, 7, 40, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 27,
					CustomerName = "Lúcia Carvalho",
					Amount = 1573.4m,
					Fee = 9.65m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 2, 17, 4, 26, 32, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 28,
					CustomerName = "Isabel de Castro",
					Amount = -456.49m,
					Fee = 11.23m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 9, 20, 10, 16, 31, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 29,
					CustomerName = "Anabela Domingues",
					Amount = -534.96m,
					Fee = 4.84m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 11, 1, 9, 21, 25, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 30,
					CustomerName = "Manuel Pereira",
					Amount = 730.26m,
					Fee = 2.08m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 3, 7, 1, 23, 6, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 31,
					CustomerName = "Annette Roulet",
					Amount = -1648.53m,
					Fee = 0.16m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 10, 24, 8, 52, 46, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 32,
					CustomerName = "Pirkko Koskitalo",
					Amount = -106.55m,
					Fee = 6.21m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 4, 22, 6, 44, 43, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 33,
					CustomerName = "Howard Snyder",
					Amount = 1978.2m,
					Fee = 6.24m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 2, 23, 9, 15, 16, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 34,
					CustomerName = "Palle Ibsen",
					Amount = -1696.54m,
					Fee = 1.98m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 9, 26, 8, 54, 7, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 35,
					CustomerName = "Emma Johnson",
					Amount = 1467.74m,
					Fee = 8.45m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 8, 14, 10, 20, 27, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 36,
					CustomerName = "Laurence Lebihan",
					Amount = 849.49m,
					Fee = 6.2m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 7, 13, 6, 10, 13, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 37,
					CustomerName = "Daniel Tonini",
					Amount = -501.46m,
					Fee = 8.74m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 12, 20, 6, 7, 4, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 38,
					CustomerName = "Philip Cramer",
					Amount = -849.39m,
					Fee = 8.27m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 11, 10, 9, 47, 10, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 39,
					CustomerName = "Manuel Pereira",
					Amount = 1123.96m,
					Fee = 11.23m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 8, 13, 1, 52, 27, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 40,
					CustomerName = "Daniel Tonini",
					Amount = -1908.43m,
					Fee = 5.7m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 1, 26, 4, 28, 25, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 41,
					CustomerName = "Dominique Perrier",
					Amount = -1298.6m,
					Fee = 1.72m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 11, 4, 3, 43, 31, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 42,
					CustomerName = "Janine Labrune",
					Amount = 259.15m,
					Fee = 8.54m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 5, 16, 10, 13, 9, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 43,
					CustomerName = "Jose Pavarotti",
					Amount = -1916.93m,
					Fee = 8.64m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 11, 16, 4, 2, 38, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 44,
					CustomerName = "Miguel Angel Paolino",
					Amount = 1580.59m,
					Fee = 1.68m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 8, 8, 8, 32, 6, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 45,
					CustomerName = "Martine Rancé",
					Amount = 1811.23m,
					Fee = 5.03m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 3, 13, 8, 34, 42, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 46,
					CustomerName = "André Fonseca",
					Amount = -307.97m,
					Fee = 10.01m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 9, 21, 10, 5, 26, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 47,
					CustomerName = "Isabel de Castro",
					Amount = 1970.7m,
					Fee = 7.95m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 9, 15, 4, 6, 21, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 48,
					CustomerName = "Victoria Ashworth",
					Amount = 1438.05m,
					Fee = 8.53m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 12, 25, 7, 47, 40, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 49,
					CustomerName = "Antonio Moreno",
					Amount = -815.28m,
					Fee = 9.34m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 12, 10, 4, 38, 19, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 50,
					CustomerName = "Philip Cramer",
					Amount = -1630.05m,
					Fee = 7.06m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 5, 5, 9, 56, 9, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 51,
					CustomerName = "Diego Roel",
					Amount = 1092.24m,
					Fee = 5.05m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 8, 21, 4, 28, 38, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 52,
					CustomerName = "Martine Rancé",
					Amount = -480.01m,
					Fee = 8.24m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 7, 19, 5, 52, 5, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 53,
					CustomerName = "André Fonseca",
					Amount = -622.6m,
					Fee = 1.53m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 12, 20, 7, 43, 41, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 54,
					CustomerName = "Helen Bennett",
					Amount = 1267.7m,
					Fee = 4.67m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 7, 5, 9, 31, 33, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 55,
					CustomerName = "Elizabeth Lincoln",
					Amount = -1911.92m,
					Fee = 7m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 5, 13, 5, 41, 22, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 56,
					CustomerName = "Isabella Lee",
					Amount = 1317.08m,
					Fee = 0.31m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 11, 22, 9, 11, 35, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 57,
					CustomerName = "Fran Wilson",
					Amount = 1980.26m,
					Fee = 2.81m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 4, 1, 10, 16, 14, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 58,
					CustomerName = "Karl Jablonski",
					Amount = -1626.86m,
					Fee = 6.78m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 11, 6, 6, 45, 10, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 59,
					CustomerName = "Simon Crowther",
					Amount = 469.86m,
					Fee = 10.07m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 12, 10, 9, 17, 4, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 60,
					CustomerName = "Thomas Hardy",
					Amount = 298.79m,
					Fee = 1.93m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 3, 19, 8, 19, 46, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 61,
					CustomerName = "Palle Ibsen",
					Amount = -961.82m,
					Fee = 2.52m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 8, 8, 1, 4, 6, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 62,
					CustomerName = "Giovanni Rovelli",
					Amount = 946.29m,
					Fee = 6.71m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 8, 7, 7, 19, 45, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 63,
					CustomerName = "Elizabeth Lincoln",
					Amount = 542.43m,
					Fee = 3.14m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 6, 22, 6, 24, 56, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 64,
					CustomerName = "Frédérique Citeaux",
					Amount = -903.05m,
					Fee = 9.88m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 11, 6, 8, 11, 50, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 65,
					CustomerName = "Zbyszek Piestrzeniewicz",
					Amount = -1023.59m,
					Fee = 7.65m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 2, 21, 3, 17, 41, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 66,
					CustomerName = "John Steel",
					Amount = 835.11m,
					Fee = 6.11m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 5, 7, 1, 46, 4, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 67,
					CustomerName = "Patricia McKenna",
					Amount = -625.11m,
					Fee = 6.23m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 9, 23, 5, 8, 6, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 68,
					CustomerName = "Christina Berglund",
					Amount = -538.51m,
					Fee = 10.51m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 12, 24, 10, 19, 54, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 69,
					CustomerName = "Ethan Wilson",
					Amount = 1210.7m,
					Fee = 10.04m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 1, 26, 1, 44, 47, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 70,
					CustomerName = "Paolo Accorti",
					Amount = -1200.39m,
					Fee = 1.54m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 8, 12, 9, 14, 58, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 71,
					CustomerName = "James Miller",
					Amount = 1596.52m,
					Fee = 10.98m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 4, 26, 8, 58, 6, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 72,
					CustomerName = "Karl Jablonski",
					Amount = 757.39m,
					Fee = 6.06m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 11, 15, 4, 54, 7, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 73,
					CustomerName = "Yang Wang",
					Amount = -440.93m,
					Fee = 10.74m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 7, 15, 7, 38, 16, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 74,
					CustomerName = "Francisco Chang",
					Amount = -1292.2m,
					Fee = 5.96m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 10, 11, 4, 1, 17, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 75,
					CustomerName = "Mia Davis",
					Amount = 707.33m,
					Fee = 10.37m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 6, 5, 6, 39, 52, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 76,
					CustomerName = "Rita Müller",
					Amount = -1954.57m,
					Fee = 3.58m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 5, 10, 3, 7, 36, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 77,
					CustomerName = "Ana Trujillo",
					Amount = -803.78m,
					Fee = 9.19m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 10, 1, 7, 40, 52, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 78,
					CustomerName = "Peter Franken",
					Amount = 773.15m,
					Fee = 1.34m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 12, 6, 5, 50, 52, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 79,
					CustomerName = "Felipe Izquierdo",
					Amount = -1465.02m,
					Fee = 4.68m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 8, 25, 9, 41, 4, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 80,
					CustomerName = "Isabella Lee",
					Amount = -1616.75m,
					Fee = 3.63m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 12, 10, 3, 3, 23, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 81,
					CustomerName = "Helen Bennett",
					Amount = 1153.11m,
					Fee = 7.75m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 7, 5, 4, 52, 2, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 82,
					CustomerName = "Lucas Brown",
					Amount = -1298.61m,
					Fee = 5.2m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 4, 11, 10, 11, 52, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 83,
					CustomerName = "Pedro Afonso",
					Amount = -594.67m,
					Fee = 11.87m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 5, 20, 7, 11, 47, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 84,
					CustomerName = "Mario Pontes",
					Amount = 55.94m,
					Fee = 1.02m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 4, 26, 9, 37, 36, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 85,
					CustomerName = "Paula Parente",
					Amount = -932.12m,
					Fee = 4.15m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 2, 8, 2, 27, 48, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 86,
					CustomerName = "Henriette Pfalzheim",
					Amount = -489.31m,
					Fee = 2.95m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 10, 3, 9, 49, 17, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 87,
					CustomerName = "Carine Schmitt",
					Amount = 1604.84m,
					Fee = 2.6m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 7, 27, 1, 2, 10, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 88,
					CustomerName = "Laurence Lebihan",
					Amount = -725.53m,
					Fee = 9.86m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 2, 13, 9, 35, 56, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 89,
					CustomerName = "Bernardo Batista",
					Amount = 76.55m,
					Fee = 5.61m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 5, 22, 2, 5, 6, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 90,
					CustomerName = "Patricio Simpson",
					Amount = 706.55m,
					Fee = 6.27m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 1, 22, 9, 34, 29, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 91,
					CustomerName = "Guillermo Fernández",
					Amount = -250.98m,
					Fee = 11.34m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 3, 15, 6, 32, 48, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 92,
					CustomerName = "Georg Pipps",
					Amount = -1213.25m,
					Fee = 4.26m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 7, 21, 4, 21, 26, DateTimeKind.Utc),
					Description = "Supplier Payment",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 93,
					CustomerName = "Carine Schmitt",
					Amount = 361.29m,
					Fee = 7.11m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 12, 24, 5, 10, 58, DateTimeKind.Utc),
					Description = "Counter Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 94,
					CustomerName = "Liz Nixon",
					Amount = -1222.52m,
					Fee = 9.1m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 11, 10, 2, 57, 2, DateTimeKind.Utc),
					Description = "Direct Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 95,
					CustomerName = "Charlotte Wilson",
					Amount = -1809.24m,
					Fee = 3.35m,
					Currency = "EUR",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 4, 22, 3, 50, 22, DateTimeKind.Utc),
					Description = "Online Transfer",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 96,
					CustomerName = "Frédérique Citeaux",
					Amount = 978.33m,
					Fee = 3.56m,
					Currency = "USD",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 10, 12, 7, 15, 36, DateTimeKind.Utc),
					Description = "Invoice Payment",
					Region = "East"
				},
				new CustomerDto()
				{
					Id = 97,
					CustomerName = "Karl Jablonski",
					Amount = -1192.23m,
					Fee = 1.01m,
					Currency = "EUR",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 5, 8, 8, 32, 9, DateTimeKind.Utc),
					Description = "ATM Withdrawal",
					Region = "West"
				},
				new CustomerDto()
				{
					Id = 98,
					CustomerName = "Pascale Cartrain",
					Amount = 491.03m,
					Fee = 1.83m,
					Currency = "USD",
					Status = "Failed",
					TransactionType = "Transfer",
					AccountType = "Business",
					TransactionDate = new DateTime(2025, 10, 26, 2, 34, 24, DateTimeKind.Utc),
					Description = "Bonus Deposit",
					Region = "North"
				},
				new CustomerDto()
				{
					Id = 99,
					CustomerName = "Alejandra Camino",
					Amount = 1550.74m,
					Fee = 10.86m,
					Currency = "EUR",
					Status = "Completed",
					TransactionType = "Deposit",
					AccountType = "Checking",
					TransactionDate = new DateTime(2025, 3, 14, 6, 10, 49, DateTimeKind.Utc),
					Description = "Paycheck Deposit",
					Region = "South"
				},
				new CustomerDto()
				{
					Id = 100,
					CustomerName = "Maria Larsson",
					Amount = -1769.47m,
					Fee = 5.12m,
					Currency = "USD",
					Status = "Pending",
					TransactionType = "Withdrawal",
					AccountType = "Savings",
					TransactionDate = new DateTime(2025, 9, 17, 4, 4, 32, DateTimeKind.Utc),
					Description = "Bank Withdrawal",
					Region = "East"
				},
			};

			return data;
		}
	}

	public class CustomerDto
	{
		public int Id { get; set; }

		public string CustomerName { get; set; }

		public decimal Amount { get; set; }

		public decimal Fee { get; set; }

		public string Currency { get; set; }

		public string Status { get; set; }

		public string TransactionType { get; set; }

		public string AccountType { get; set; }

		public DateTime TransactionDate { get; set; }

		public string Description { get; set; }

		public string Region { get; set; }
	}
