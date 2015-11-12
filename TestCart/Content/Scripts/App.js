(function (w, undefined)
{
    function loadApp()
    {
        var app =
            {
                'Events': new w['AppEventsLoader'](),
                'Service': new w['AppServiceLoader'](),
                'Constants': new w['AppConstantsLoader'](),
                'Templates': new w['AppTemplatesLoader']()
            };

        w['App'] = app;

        //There is no going back now!!
        if (w['LoadApp']) w['LoadApp'] = undefined;
        if (w['AppEventLoader']) w['AppEventLoader'] = undefined;
        if (w['AppServiceLoader']) w['AppServiceLoader'] = undefined;
        if (w['AppConstantsLoader']) w['AppConstantsLoader'] = undefined;
        if (w['AppTemplatesLoader']) w['AppTemplatesLoader'] = undefined;
    }
    
    w['LoadApp'] = loadApp;
})(window);