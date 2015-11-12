<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="TestCart.Product"  MasterPageFile="~/Master.Master" %>

<asp:Content ID="product" runat="server" ContentPlaceHolderID="MainPlaceHolder">

    <div id="divProduct">

    </div>

    <script>
        $(document).ready(function ()
        {
            var app = window.App;
            if (app)
            {
                app.Service.Call('GetProduct', { 'Id': getParameterByName('id') }).then(function (data)
                {
                    $divProduct = $('#divProduct');

                    //Our callback
                    function setHtml(html)
                    {
                        $divProduct.html(html);
                    }

                    app.Templates.GetTemplateHtmlAjax('ProductItem', data, setHtml.bind(this));
                })
            }

            //To read id from the url
            //http://stackoverflow.com/questions/901115/how-can-i-get-query-string-values-in-javascript
            function getParameterByName(name)
            {
                name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
                var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                    results = regex.exec(location.search);
                return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
            }
        });
    </script>

</asp:Content>
