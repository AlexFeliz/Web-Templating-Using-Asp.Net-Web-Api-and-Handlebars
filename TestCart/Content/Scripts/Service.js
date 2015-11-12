;
(function (w, $)
{
    var serviceLoader = function ()
    {
        this.Call = function (type, args)
        {
            var url = w.App.Constants.ServiceMap[type];

            if (!args) return $.getJSON(url);
            else return $.getJSON(url, args);
        };
    };
    
    w['AppServiceLoader'] = serviceLoader;
})(window, jQuery);