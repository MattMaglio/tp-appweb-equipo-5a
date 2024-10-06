<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bases.aspx.cs" Inherits="WebApp.Bases" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container mt-4">
        <h1><strong>Bases y Condiciones de Participación</strong></h1>
        <br>
        <br>

        <p style="text-align: justify;"><strong>Bienvenido a Promo Ganá!. Al participar, aceptas las siguientes bases y condiciones que rigen la entrega de vouchers y la selección de premios.</strong></p>

        <p style="text-align: justify;"><strong>Obtención de Vouchers:</strong> Los vouchers son otorgados a los clientes que realicen compras en nuestro establecimiento. Por cada compra, recibirás un código promocional único que podrás utilizar para participar en el sorteo de premios.</p>
        <p style="text-align: justify;"><strong>Ingreso del Código Promocional:</strong> Para participar, deberás ingresar a la página web proporcionada e ingresar el código promocional recibido. El sistema verificará la validez del código chequeando su existencia en nuestra base de datos.</p>
        <p style="text-align: justify;">
            <strong>Validación del Código:</strong>

        <p style="text-align: justify;">Si el código ingresado es válido y no ha sido utilizado, el cliente podrá proceder a seleccionar el premio que desea.</p>
        <p style="text-align: justify;">Si el código es incorrecto o ya ha sido utilizado, se mostrará un mensaje aclaratorio informando sobre la situación y se ofrecerá un botón para regresar al inicio de la página.</p>


        <p style="text-align: justify;"><strong>Selección de Premios:</strong> Una vez validado el código, el participante podrá elegir el premio que desea. Los premios estarán disponibles en la página de la promoción y se detallarán claramente.</p>
        <p style="text-align: justify;"><strong>Responsabilidad del Participante:</strong> El cliente es responsable de ingresar correctamente el código promocional. Promo Ganá! no se hace responsable por códigos ingresados incorrectamente o por errores en el ingreso de datos.</p>
        <p style="text-align: justify;"><strong>Modificaciones:</strong> Promo Ganá! se reserva el derecho de modificar estas bases y condiciones en cualquier momento. Cualquier cambio será notificado a los participantes a través de la página web.</p>
        <p style="text-align: justify;"><strong>Aceptación de Bases:</strong> La participación en la promoción implica la aceptación de estas bases y condiciones. </p>


        <p style="text-align: justify;">Para más información, no dudes en contactarnos a través de nuestros canales de atención al cliente.</p>
    </div>
    <br>

    <div class="mb-3">
        <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-primary" OnClick="btnVolver_Click" runat="server" />
    </div>
</asp:Content>
