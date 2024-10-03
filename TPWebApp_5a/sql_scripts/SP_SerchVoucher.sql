CREATE PROCEDURE SearchVoucher @cod_voucher varchar(50) AS
SELECT CodigoVoucher ,
       IdCliente ,
       FechaCanje ,
       IdArticulo
FROM Vouchers
WHERE CodigoVoucher = @cod_voucher