///*
// * JON FAZZARO
// * URL: http://blog.apterainc.com/bid/313071/Turn-your-ASP-NET-MVC-app-into-a-Single-Page-Application-with-one-classy-Sammy-js-route
// * 
// * */

//var Routing = function (appRoot, contentSelector, defaultRoute) {
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="appRoot" type="type"></param>
//    /// <param name="contentSelector" type="type">Element </param>
//    /// <param name="defaultRoute" type="type"></param>
//    /// <returns type=""></returns>

//    var target = defaultRoute;

//    function getUrlFromHash(hash) {
//        /// <summary>
//        /// Get the url without hash[#]
//        /// </summary>
//        /// <param name="hash" type="type"></param>
//        /// <returns type=""></returns>
//        var url = hash.replace('#/', '');
//        if (url === appRoot)
//            url = defaultRoute;
//        return url;
//    }

//    return {
//        init: function () {
//            /// <summary>
//            /// Load content of url inner elemenet [contentSelector]
//            /// </summary>
//            Sammy(contentSelector, function () {

//                this.get(target, function (context) {
//                    var url = getUrlFromHash(context.path);
//                    context.load(url).swap();
//                });


//            }).run('#/');
//        }
//    };
//}