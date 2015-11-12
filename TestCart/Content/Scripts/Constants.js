;
(function (w)
{
    var constantsLoader = function ()
    {
        this.ServiceMap =
        {
            'GetAllProducts': '/api/Product/',
            'GetProduct': '/api/Product/'
        };

        this.TemplateMap =
        {
            'ProductGrid': 'Content/Templates/ProductGrid.html',
            'ProductItem': 'Content/Templates/ProductItem.html'
        };
    };

    w['AppConstantsLoader'] = constantsLoader;

})(window);