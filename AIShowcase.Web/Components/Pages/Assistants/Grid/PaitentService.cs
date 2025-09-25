namespace AIShowcase.WebApp.Components.Pages.Assistants.Grid;
using System;
using System.Collections.Generic;

	public class PatientService
	{
		public List<PatientDto> GetData()
		{
			var data = new List<PatientDto>()
			{
				new PatientDto()
				{
					Id = 1,
					PatientName = "Fran Wilson",
					Age = 52,
					ConditionSeverity = "Severe",
					Department = "Oncology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 5, 1, 4, 31, 46, DateTimeKind.Utc),
					RiskScore = 40
				},
				new PatientDto()
				{
					Id = 2,
					PatientName = "Sergio Gutiérrez",
					Age = 27,
					ConditionSeverity = "Moderate",
					Department = "Neurology",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 4, 14, 9, 43, 53, DateTimeKind.Utc),
					RiskScore = 20
				},
				new PatientDto()
				{
					Id = 3,
					PatientName = "Pirkko Koskitalo",
					Age = 20,
					ConditionSeverity = "Mild",
					Department = "Intense Care",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 12, 9, 2, 54, 31, DateTimeKind.Utc),
					RiskScore = 12
				},
				new PatientDto()
				{
					Id = 4,
					PatientName = "Isabella Lee",
					Age = 5,
					ConditionSeverity = "Clinical",
					Department = "Endocrionology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 8, 27, 5, 13, 20, DateTimeKind.Utc),
					RiskScore = 23
				},
				new PatientDto()
				{
					Id = 5,
					PatientName = "Eduardo Saavedra",
					Age = 48,
					ConditionSeverity = "Critical",
					Department = "Emergency",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 1, 5, 2, 6, 18, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 6,
					PatientName = "Olivia King",
					Age = 32,
					ConditionSeverity = "Severe",
					Department = "General",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 6, 21, 4, 49, 11, DateTimeKind.Utc),
					RiskScore = 64
				},
				new PatientDto()
				{
					Id = 7,
					PatientName = "Helen Bennett",
					Age = 11,
					ConditionSeverity = "Moderate",
					Department = "Nephrology",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 2, 6, 8, 43, 25, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 8,
					PatientName = "Frédérique Citeaux",
					Age = 6,
					ConditionSeverity = "Mild",
					Department = "Rheumatology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 9, 10, 10, 41, 51, DateTimeKind.Utc),
					RiskScore = 94
				},
				new PatientDto()
				{
					Id = 9,
					PatientName = "Thomas Hardy",
					Age = 14,
					ConditionSeverity = "Clinical",
					Department = "Gastroenterology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 4, 10, 10, 44, 32, DateTimeKind.Utc),
					RiskScore = 30
				},
				new PatientDto()
				{
					Id = 10,
					PatientName = "Rita Müller",
					Age = 38,
					ConditionSeverity = "Critical",
					Department = "Neurosurgery",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 3, 23, 7, 58, 54, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 11,
					PatientName = "Annette Roulet",
					Age = 69,
					ConditionSeverity = "Severe",
					Department = "Dermatology",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 4, 16, 8, 58, 2, DateTimeKind.Utc),
					RiskScore = 6
				},
				new PatientDto()
				{
					Id = 12,
					PatientName = "Charlotte Wilson",
					Age = 19,
					ConditionSeverity = "Moderate",
					Department = "Anestesiology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 5, 15, 3, 7, 7, DateTimeKind.Utc),
					RiskScore = 7
				},
				new PatientDto()
				{
					Id = 13,
					PatientName = "Liu Wong",
					Age = 32,
					ConditionSeverity = "Mild",
					Department = "Oncology",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 12, 25, 3, 37, 30, DateTimeKind.Utc),
					RiskScore = 26
				},
				new PatientDto()
				{
					Id = 14,
					PatientName = "Art Braunschweiger",
					Age = 2,
					ConditionSeverity = "Clinical",
					Department = "Neurology",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 10, 16, 7, 31, 3, DateTimeKind.Utc),
					RiskScore = 67
				},
				new PatientDto()
				{
					Id = 15,
					PatientName = "Roland Mendel",
					Age = 1,
					ConditionSeverity = "Critical",
					Department = "Intense Care",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 11, 13, 5, 26, 47, DateTimeKind.Utc),
					RiskScore = 30
				},
				new PatientDto()
				{
					Id = 16,
					PatientName = "Ann Devon",
					Age = 69,
					ConditionSeverity = "Severe",
					Department = "Endocrionology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 6, 24, 9, 50, 13, DateTimeKind.Utc),
					RiskScore = 90
				},
				new PatientDto()
				{
					Id = 17,
					PatientName = "Olivia King",
					Age = 46,
					ConditionSeverity = "Moderate",
					Department = "Emergency",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 12, 18, 8, 10, 28, DateTimeKind.Utc),
					RiskScore = 15
				},
				new PatientDto()
				{
					Id = 18,
					PatientName = "Elizabeth Brown",
					Age = 58,
					ConditionSeverity = "Mild",
					Department = "General",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 8, 22, 9, 21, 48, DateTimeKind.Utc),
					RiskScore = 22
				},
				new PatientDto()
				{
					Id = 19,
					PatientName = "José Pedro Freyre",
					Age = 60,
					ConditionSeverity = "Clinical",
					Department = "Nephrology",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 1, 14, 10, 44, 42, DateTimeKind.Utc),
					RiskScore = 12
				},
				new PatientDto()
				{
					Id = 20,
					PatientName = "Christina Berglund",
					Age = 36,
					ConditionSeverity = "Critical",
					Department = "Rheumatology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 8, 26, 7, 13, 46, DateTimeKind.Utc),
					RiskScore = 22
				},
				new PatientDto()
				{
					Id = 21,
					PatientName = "Olivia King",
					Age = 48,
					ConditionSeverity = "Severe",
					Department = "Gastroenterology",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 4, 21, 1, 44, 29, DateTimeKind.Utc),
					RiskScore = 21
				},
				new PatientDto()
				{
					Id = 22,
					PatientName = "Yoshi Tannamuri",
					Age = 58,
					ConditionSeverity = "Moderate",
					Department = "Neurosurgery",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 4, 11, 1, 9, 52, DateTimeKind.Utc),
					RiskScore = 65
				},
				new PatientDto()
				{
					Id = 23,
					PatientName = "Guillermo Fernández",
					Age = 60,
					ConditionSeverity = "Mild",
					Department = "Dermatology",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 4, 7, 7, 34, 22, DateTimeKind.Utc),
					RiskScore = 21
				},
				new PatientDto()
				{
					Id = 24,
					PatientName = "Olivia King",
					Age = 34,
					ConditionSeverity = "Clinical",
					Department = "Anestesiology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 8, 10, 5, 25, 35, DateTimeKind.Utc),
					RiskScore = 91
				},
				new PatientDto()
				{
					Id = 25,
					PatientName = "Dominique Perrier",
					Age = 52,
					ConditionSeverity = "Critical",
					Department = "Oncology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 4, 19, 5, 27, 36, DateTimeKind.Utc),
					RiskScore = 26
				},
				new PatientDto()
				{
					Id = 26,
					PatientName = "Renate Messner",
					Age = 28,
					ConditionSeverity = "Severe",
					Department = "Neurology",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 1, 7, 7, 40, 28, DateTimeKind.Utc),
					RiskScore = 19
				},
				new PatientDto()
				{
					Id = 27,
					PatientName = "Patricia McKenna",
					Age = 6,
					ConditionSeverity = "Moderate",
					Department = "Intense Care",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 11, 10, 5, 17, 34, DateTimeKind.Utc),
					RiskScore = 14
				},
				new PatientDto()
				{
					Id = 28,
					PatientName = "Palle Ibsen",
					Age = 65,
					ConditionSeverity = "Mild",
					Department = "Endocrionology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 10, 11, 8, 15, 31, DateTimeKind.Utc),
					RiskScore = 22
				},
				new PatientDto()
				{
					Id = 29,
					PatientName = "Roland Mendel",
					Age = 37,
					ConditionSeverity = "Clinical",
					Department = "Emergency",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 12, 26, 7, 28, 38, DateTimeKind.Utc),
					RiskScore = 2
				},
				new PatientDto()
				{
					Id = 30,
					PatientName = "Fran Wilson",
					Age = 41,
					ConditionSeverity = "Critical",
					Department = "General",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 8, 11, 10, 7, 25, DateTimeKind.Utc),
					RiskScore = 71
				},
				new PatientDto()
				{
					Id = 31,
					PatientName = "Lúcia Carvalho",
					Age = 39,
					ConditionSeverity = "Severe",
					Department = "Nephrology",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 6, 1, 10, 19, 3, DateTimeKind.Utc),
					RiskScore = 21
				},
				new PatientDto()
				{
					Id = 32,
					PatientName = "Matti Karttunen",
					Age = 20,
					ConditionSeverity = "Moderate",
					Department = "Rheumatology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 5, 25, 1, 5, 14, DateTimeKind.Utc),
					RiskScore = 90
				},
				new PatientDto()
				{
					Id = 33,
					PatientName = "Renate Messner",
					Age = 68,
					ConditionSeverity = "Mild",
					Department = "Gastroenterology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 7, 21, 2, 30, 11, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 34,
					PatientName = "Sophia Turner",
					Age = 30,
					ConditionSeverity = "Clinical",
					Department = "Neurosurgery",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 10, 18, 9, 20, 9, DateTimeKind.Utc),
					RiskScore = 28
				},
				new PatientDto()
				{
					Id = 35,
					PatientName = "Rita Müller",
					Age = 59,
					ConditionSeverity = "Critical",
					Department = "Dermatology",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 3, 18, 5, 28, 44, DateTimeKind.Utc),
					RiskScore = 5
				},
				new PatientDto()
				{
					Id = 36,
					PatientName = "Manuel Pereira",
					Age = 42,
					ConditionSeverity = "Severe",
					Department = "Anestesiology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 8, 12, 3, 21, 46, DateTimeKind.Utc),
					RiskScore = 21
				},
				new PatientDto()
				{
					Id = 37,
					PatientName = "Aria Cruz",
					Age = 23,
					ConditionSeverity = "Moderate",
					Department = "Oncology",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 5, 10, 1, 53, 52, DateTimeKind.Utc),
					RiskScore = 25
				},
				new PatientDto()
				{
					Id = 38,
					PatientName = "Maria Larsson",
					Age = 40,
					ConditionSeverity = "Mild",
					Department = "Neurology",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 5, 5, 2, 56, 13, DateTimeKind.Utc),
					RiskScore = 66
				},
				new PatientDto()
				{
					Id = 39,
					PatientName = "Helen Bennett",
					Age = 60,
					ConditionSeverity = "Clinical",
					Department = "Intense Care",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 7, 24, 7, 45, 37, DateTimeKind.Utc),
					RiskScore = 7
				},
				new PatientDto()
				{
					Id = 40,
					PatientName = "Philip Cramer",
					Age = 21,
					ConditionSeverity = "Critical",
					Department = "Endocrionology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 5, 22, 9, 19, 26, DateTimeKind.Utc),
					RiskScore = 96
				},
				new PatientDto()
				{
					Id = 41,
					PatientName = "Jaime Yorres",
					Age = 11,
					ConditionSeverity = "Severe",
					Department = "Emergency",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 4, 21, 8, 56, 55, DateTimeKind.Utc),
					RiskScore = 25
				},
				new PatientDto()
				{
					Id = 42,
					PatientName = "Ana Trujillo",
					Age = 28,
					ConditionSeverity = "Moderate",
					Department = "General",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 1, 9, 1, 26, 45, DateTimeKind.Utc),
					RiskScore = 26
				},
				new PatientDto()
				{
					Id = 43,
					PatientName = "Janete Limeira",
					Age = 6,
					ConditionSeverity = "Mild",
					Department = "Nephrology",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 1, 15, 6, 25, 19, DateTimeKind.Utc),
					RiskScore = 8
				},
				new PatientDto()
				{
					Id = 44,
					PatientName = "Carlos González",
					Age = 60,
					ConditionSeverity = "Clinical",
					Department = "Rheumatology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 5, 6, 6, 10, 42, DateTimeKind.Utc),
					RiskScore = 30
				},
				new PatientDto()
				{
					Id = 45,
					PatientName = "Martín Sommer",
					Age = 44,
					ConditionSeverity = "Critical",
					Department = "Gastroenterology",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 7, 13, 6, 21, 8, DateTimeKind.Utc),
					RiskScore = 22
				},
				new PatientDto()
				{
					Id = 46,
					PatientName = "Horst Kloss",
					Age = 15,
					ConditionSeverity = "Severe",
					Department = "Neurosurgery",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 1, 17, 7, 24, 21, DateTimeKind.Utc),
					RiskScore = 70
				},
				new PatientDto()
				{
					Id = 47,
					PatientName = "Noah Smith",
					Age = 37,
					ConditionSeverity = "Moderate",
					Department = "Dermatology",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 4, 19, 3, 49, 23, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 48,
					PatientName = "Yang Wang",
					Age = 39,
					ConditionSeverity = "Mild",
					Department = "Anestesiology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 2, 7, 8, 5, 51, DateTimeKind.Utc),
					RiskScore = 97
				},
				new PatientDto()
				{
					Id = 49,
					PatientName = "Lucas Brown",
					Age = 19,
					ConditionSeverity = "Clinical",
					Department = "Oncology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 3, 10, 3, 15, 33, DateTimeKind.Utc),
					RiskScore = 24
				},
				new PatientDto()
				{
					Id = 50,
					PatientName = "Ann Devon",
					Age = 14,
					ConditionSeverity = "Critical",
					Department = "Neurology",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 9, 6, 7, 57, 25, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 51,
					PatientName = "Thomas Hardy",
					Age = 63,
					ConditionSeverity = "Severe",
					Department = "Intense Care",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 5, 5, 6, 40, 9, DateTimeKind.Utc),
					RiskScore = 7
				},
				new PatientDto()
				{
					Id = 52,
					PatientName = "Zbyszek Piestrzeniewicz",
					Age = 69,
					ConditionSeverity = "Moderate",
					Department = "Endocrionology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 11, 21, 5, 58, 39, DateTimeKind.Utc),
					RiskScore = 27
				},
				new PatientDto()
				{
					Id = 53,
					PatientName = "Patricio Simpson",
					Age = 11,
					ConditionSeverity = "Mild",
					Department = "Emergency",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 1, 21, 4, 29, 43, DateTimeKind.Utc),
					RiskScore = 3
				},
				new PatientDto()
				{
					Id = 54,
					PatientName = "Olivia King",
					Age = 70,
					ConditionSeverity = "Clinical",
					Department = "General",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 7, 1, 2, 7, 27, DateTimeKind.Utc),
					RiskScore = 65
				},
				new PatientDto()
				{
					Id = 55,
					PatientName = "Annette Roulet",
					Age = 47,
					ConditionSeverity = "Critical",
					Department = "Nephrology",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 11, 12, 10, 40, 12, DateTimeKind.Utc),
					RiskScore = 28
				},
				new PatientDto()
				{
					Id = 56,
					PatientName = "Eduardo Saavedra",
					Age = 1,
					ConditionSeverity = "Severe",
					Department = "Rheumatology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 5, 23, 4, 43, 25, DateTimeKind.Utc),
					RiskScore = 96
				},
				new PatientDto()
				{
					Id = 57,
					PatientName = "Fran Wilson",
					Age = 11,
					ConditionSeverity = "Moderate",
					Department = "Gastroenterology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 12, 26, 3, 13, 52, DateTimeKind.Utc),
					RiskScore = 27
				},
				new PatientDto()
				{
					Id = 58,
					PatientName = "Maurizio Moroni",
					Age = 45,
					ConditionSeverity = "Mild",
					Department = "Neurosurgery",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 1, 25, 7, 42, 13, DateTimeKind.Utc),
					RiskScore = 26
				},
				new PatientDto()
				{
					Id = 59,
					PatientName = "Helen Bennett",
					Age = 49,
					ConditionSeverity = "Clinical",
					Department = "Dermatology",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 12, 25, 3, 10, 50, DateTimeKind.Utc),
					RiskScore = 7
				},
				new PatientDto()
				{
					Id = 60,
					PatientName = "Liu Wong",
					Age = 62,
					ConditionSeverity = "Critical",
					Department = "Anestesiology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 7, 13, 7, 26, 19, DateTimeKind.Utc),
					RiskScore = 24
				},
				new PatientDto()
				{
					Id = 61,
					PatientName = "Fran Wilson",
					Age = 15,
					ConditionSeverity = "Severe",
					Department = "Oncology",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 8, 11, 7, 30, 58, DateTimeKind.Utc),
					RiskScore = 6
				},
				new PatientDto()
				{
					Id = 62,
					PatientName = "Frédérique Citeaux",
					Age = 8,
					ConditionSeverity = "Moderate",
					Department = "Neurology",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 7, 22, 10, 55, 49, DateTimeKind.Utc),
					RiskScore = 71
				},
				new PatientDto()
				{
					Id = 63,
					PatientName = "Martine Rancé",
					Age = 46,
					ConditionSeverity = "Mild",
					Department = "Intense Care",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 9, 14, 9, 42, 15, DateTimeKind.Utc),
					RiskScore = 26
				},
				new PatientDto()
				{
					Id = 64,
					PatientName = "José Pedro Freyre",
					Age = 57,
					ConditionSeverity = "Clinical",
					Department = "Endocrionology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 8, 18, 2, 46, 26, DateTimeKind.Utc),
					RiskScore = 91
				},
				new PatientDto()
				{
					Id = 65,
					PatientName = "Lucas Brown",
					Age = 57,
					ConditionSeverity = "Critical",
					Department = "Emergency",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 9, 6, 2, 14, 15, DateTimeKind.Utc),
					RiskScore = 1
				},
				new PatientDto()
				{
					Id = 66,
					PatientName = "Francisco Chang",
					Age = 22,
					ConditionSeverity = "Severe",
					Department = "General",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 2, 7, 5, 45, 44, DateTimeKind.Utc),
					RiskScore = 26
				},
				new PatientDto()
				{
					Id = 67,
					PatientName = "Carlos Hernández",
					Age = 61,
					ConditionSeverity = "Moderate",
					Department = "Nephrology",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 3, 16, 8, 16, 34, DateTimeKind.Utc),
					RiskScore = 5
				},
				new PatientDto()
				{
					Id = 68,
					PatientName = "Maurizio Moroni",
					Age = 67,
					ConditionSeverity = "Mild",
					Department = "Rheumatology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 3, 3, 10, 30, 4, DateTimeKind.Utc),
					RiskScore = 21
				},
				new PatientDto()
				{
					Id = 69,
					PatientName = "Zbyszek Piestrzeniewicz",
					Age = 68,
					ConditionSeverity = "Clinical",
					Department = "Gastroenterology",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 5, 17, 5, 19, 47, DateTimeKind.Utc),
					RiskScore = 2
				},
				new PatientDto()
				{
					Id = 70,
					PatientName = "Yoshi Latimer",
					Age = 14,
					ConditionSeverity = "Critical",
					Department = "Neurosurgery",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 1, 13, 5, 8, 41, DateTimeKind.Utc),
					RiskScore = 70
				},
				new PatientDto()
				{
					Id = 71,
					PatientName = "Paula Parente",
					Age = 21,
					ConditionSeverity = "Severe",
					Department = "Dermatology",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 4, 8, 5, 50, 13, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 72,
					PatientName = "Martín Sommer",
					Age = 32,
					ConditionSeverity = "Moderate",
					Department = "Anestesiology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 5, 2, 5, 30, 4, DateTimeKind.Utc),
					RiskScore = 97
				},
				new PatientDto()
				{
					Id = 73,
					PatientName = "Mia Davis",
					Age = 67,
					ConditionSeverity = "Mild",
					Department = "Oncology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 9, 13, 6, 13, 16, DateTimeKind.Utc),
					RiskScore = 24
				},
				new PatientDto()
				{
					Id = 74,
					PatientName = "Frédérique Citeaux",
					Age = 69,
					ConditionSeverity = "Clinical",
					Department = "Neurology",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 4, 22, 10, 51, 52, DateTimeKind.Utc),
					RiskScore = 24
				},
				new PatientDto()
				{
					Id = 75,
					PatientName = "Mario Pontes",
					Age = 58,
					ConditionSeverity = "Critical",
					Department = "Intense Care",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 3, 15, 3, 22, 51, DateTimeKind.Utc),
					RiskScore = 8
				},
				new PatientDto()
				{
					Id = 76,
					PatientName = "Howard Snyder",
					Age = 43,
					ConditionSeverity = "Severe",
					Department = "Endocrionology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 4, 15, 2, 29, 33, DateTimeKind.Utc),
					RiskScore = 26
				},
				new PatientDto()
				{
					Id = 77,
					PatientName = "Fran Wilson",
					Age = 46,
					ConditionSeverity = "Moderate",
					Department = "Emergency",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 12, 5, 6, 38, 16, DateTimeKind.Utc),
					RiskScore = 27
				},
				new PatientDto()
				{
					Id = 78,
					PatientName = "Michael Holz",
					Age = 14,
					ConditionSeverity = "Mild",
					Department = "General",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 7, 9, 5, 5, 53, DateTimeKind.Utc),
					RiskScore = 68
				},
				new PatientDto()
				{
					Id = 79,
					PatientName = "Lucas Brown",
					Age = 10,
					ConditionSeverity = "Clinical",
					Department = "Nephrology",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 2, 4, 7, 5, 3, DateTimeKind.Utc),
					RiskScore = 27
				},
				new PatientDto()
				{
					Id = 80,
					PatientName = "Maria Anders",
					Age = 35,
					ConditionSeverity = "Critical",
					Department = "Rheumatology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 9, 19, 5, 38, 51, DateTimeKind.Utc),
					RiskScore = 96
				},
				new PatientDto()
				{
					Id = 81,
					PatientName = "Giovanni Rovelli",
					Age = 49,
					ConditionSeverity = "Severe",
					Department = "Gastroenterology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 10, 10, 2, 9, 39, DateTimeKind.Utc),
					RiskScore = 24
				},
				new PatientDto()
				{
					Id = 82,
					PatientName = "Peter Franken",
					Age = 67,
					ConditionSeverity = "Moderate",
					Department = "Neurosurgery",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 1, 11, 8, 24, 58, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 83,
					PatientName = "Karl Jablonski",
					Age = 19,
					ConditionSeverity = "Mild",
					Department = "Dermatology",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 6, 9, 1, 32, 35, DateTimeKind.Utc),
					RiskScore = 12
				},
				new PatientDto()
				{
					Id = 84,
					PatientName = "Elizabeth Brown",
					Age = 28,
					ConditionSeverity = "Clinical",
					Department = "Anestesiology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 6, 20, 3, 4, 27, DateTimeKind.Utc),
					RiskScore = 28
				},
				new PatientDto()
				{
					Id = 85,
					PatientName = "Martine Rancé",
					Age = 58,
					ConditionSeverity = "Critical",
					Department = "Oncology",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 2, 1, 7, 35, 27, DateTimeKind.Utc),
					RiskScore = 29
				},
				new PatientDto()
				{
					Id = 86,
					PatientName = "Ethan Wilson",
					Age = 11,
					ConditionSeverity = "Severe",
					Department = "Neurology",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 2, 24, 4, 1, 54, DateTimeKind.Utc),
					RiskScore = 65
				},
				new PatientDto()
				{
					Id = 87,
					PatientName = "Helen Bennett",
					Age = 52,
					ConditionSeverity = "Moderate",
					Department = "Intense Care",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 8, 11, 10, 53, 7, DateTimeKind.Utc),
					RiskScore = 1
				},
				new PatientDto()
				{
					Id = 88,
					PatientName = "Martín Sommer",
					Age = 2,
					ConditionSeverity = "Mild",
					Department = "Endocrionology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 9, 8, 9, 1, 47, DateTimeKind.Utc),
					RiskScore = 89
				},
				new PatientDto()
				{
					Id = 89,
					PatientName = "Elizabeth Brown",
					Age = 54,
					ConditionSeverity = "Clinical",
					Department = "Emergency",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 4, 14, 8, 29, 36, DateTimeKind.Utc),
					RiskScore = 27
				},
				new PatientDto()
				{
					Id = 90,
					PatientName = "Christina Berglund",
					Age = 68,
					ConditionSeverity = "Critical",
					Department = "General",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 2, 20, 9, 48, 14, DateTimeKind.Utc),
					RiskScore = 9
				},
				new PatientDto()
				{
					Id = 91,
					PatientName = "Karin Josephs",
					Age = 55,
					ConditionSeverity = "Severe",
					Department = "Nephrology",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 2, 4, 3, 32, 32, DateTimeKind.Utc),
					RiskScore = 9
				},
				new PatientDto()
				{
					Id = 92,
					PatientName = "Ann Devon",
					Age = 68,
					ConditionSeverity = "Moderate",
					Department = "Rheumatology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 2, 23, 2, 26, 30, DateTimeKind.Utc),
					RiskScore = 1
				},
				new PatientDto()
				{
					Id = 93,
					PatientName = "Pascale Cartrain",
					Age = 40,
					ConditionSeverity = "Mild",
					Department = "Gastroenterology",
					Status = "Monitoring",
					AdmissionDate = new DateTime(2025, 6, 11, 6, 41, 6, DateTimeKind.Utc),
					RiskScore = 1
				},
				new PatientDto()
				{
					Id = 94,
					PatientName = "Laurence Lebihan",
					Age = 49,
					ConditionSeverity = "Clinical",
					Department = "Neurosurgery",
					Status = "In Surgery",
					AdmissionDate = new DateTime(2025, 8, 6, 10, 12, 17, DateTimeKind.Utc),
					RiskScore = 63
				},
				new PatientDto()
				{
					Id = 95,
					PatientName = "Olivia King",
					Age = 21,
					ConditionSeverity = "Critical",
					Department = "Dermatology",
					Status = "Stable",
					AdmissionDate = new DateTime(2025, 5, 27, 10, 48, 54, DateTimeKind.Utc),
					RiskScore = 23
				},
				new PatientDto()
				{
					Id = 96,
					PatientName = "Charlotte Wilson",
					Age = 67,
					ConditionSeverity = "Severe",
					Department = "Anestesiology",
					Status = "Critical",
					AdmissionDate = new DateTime(2025, 6, 27, 9, 33, 46, DateTimeKind.Utc),
					RiskScore = 93
				},
				new PatientDto()
				{
					Id = 97,
					PatientName = "Hanna Moos",
					Age = 49,
					ConditionSeverity = "Moderate",
					Department = "Oncology",
					Status = "Under Treatment",
					AdmissionDate = new DateTime(2025, 5, 24, 8, 22, 16, DateTimeKind.Utc),
					RiskScore = 18
				},
				new PatientDto()
				{
					Id = 98,
					PatientName = "Anabela Domingues",
					Age = 48,
					ConditionSeverity = "Mild",
					Department = "Neurology",
					Status = "Awaiting Diagnosis",
					AdmissionDate = new DateTime(2025, 1, 12, 9, 27, 14, DateTimeKind.Utc),
					RiskScore = 30
				},
				new PatientDto()
				{
					Id = 99,
					PatientName = "Catherine Dewey",
					Age = 49,
					ConditionSeverity = "Clinical",
					Department = "Intense Care",
					Status = "Discharged",
					AdmissionDate = new DateTime(2025, 4, 15, 7, 5, 41, DateTimeKind.Utc),
					RiskScore = 7
				},
				new PatientDto()
				{
					Id = 100,
					PatientName = "Patricio Simpson",
					Age = 47,
					ConditionSeverity = "Critical",
					Department = "Endocrionology",
					Status = "Transferred",
					AdmissionDate = new DateTime(2025, 11, 12, 8, 30, 31, DateTimeKind.Utc),
					RiskScore = 25
				},
			};

			return data;
		}
	}

	public class PatientDto
	{
		public int Id { get; set; }

		public string PatientName { get; set; }

		public int Age { get; set; }

		public string ConditionSeverity { get; set; }

		public string Department { get; set; }

		public string Status { get; set; }

		public DateTime AdmissionDate { get; set; }

		public int RiskScore { get; set; }
	}