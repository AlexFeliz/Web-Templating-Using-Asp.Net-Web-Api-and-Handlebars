<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestCart.Default" MasterPageFile="~/Master.Master" %>

<asp:Content ID="index" runat="server" ContentPlaceHolderID="MainPlaceHolder">

    <div id="divGrid">

    </div>

    <script>
        $(document).ready(function ()
        {
            var app = window.App;
            if (app)
            {
                app.Service.Call('GetAllProducts').then(function (data)
                {
                    $divGrid = $('#divGrid');

                    //Our callback
                    function setHtml(html)
                    {
                        $divGrid.html(html);
                    }

                    app.Templates.GetTemplateHtmlAjax('ProductGrid', { 'Products': data }, setHtml.bind(this));
                })
            }
        });
    </script>

</asp:Content>
