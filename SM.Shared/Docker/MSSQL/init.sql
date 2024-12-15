IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'SalesManagement')
BEGIN
    CREATE DATABASE SalesManagement;
    PRINT 'Banco de dados SalesManagement criado com sucesso.';
END
ELSE
BEGIN
    PRINT 'Banco de dados SalesManagement já existe.';
END