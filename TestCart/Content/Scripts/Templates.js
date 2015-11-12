;
(function (w, $, h)
{
    var templatesLoader = function ()
    {
        this.GetTemplateHtmlAjax = function (name, jsonData, secondCallback)
        {
            var source;
            var template;
            var html;

            $.ajax({
                url: App.Constants.TemplateMap[name],
                cache: true  
            }).then(function (data)
            {
                source = data;
                template = h.compile(source);
                html = template(jsonData);
                secondCallback(html);
            });
        }        
    };

    w['AppTemplatesLoader'] = templatesLoader;
})(window, jQuery, Handlebars);