CREATE TABLE [dbo].[PrescripcionTbl]
(
	[PresId] INT NOT NULL PRIMARY KEY, 
    [DocId] INT NOT NULL, 
    [DocNombre] VARCHAR(50) NOT NULL, 
    [PacienteId] INT NOT NULL, 
    [PacienteNombre] VARCHAR(50) NOT NULL, 
    [LabTestId] INT NOT NULL, 
    [LabTestName] VARCHAR(50) NOT NULL, 
    [Medicamentos] VARCHAR(100) NOT NULL, 
    [Costo] INT NOT NULL
)
