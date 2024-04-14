using System.Net;

namespace APITraining.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        //create a mthod to invoke the action
        public async Task InvokeAsync(HttpContext httpcontext)
        {
            //write the try catch block you want to add to all methods in controller
            try 
            { 
                await next(httpcontext);

            } 
            catch (Exception ex) 
            {
                //let have a unique identifier for the error
                var errorId = Guid.NewGuid();
                //all exceptions in the controller will be handled here
                //Log this Exception
                logger.LogError(ex, $"{errorId} : {ex.Message}");


                //Return a custom error response
                httpcontext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpcontext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! We are looking into it"
                };

                await httpcontext.Response.WriteAsJsonAsync(error);
            }

        }
    }
}


/*1. create a ctor and inject Ilogger and RequestDelegate
 Inject this middleaware into the HTTP request pipeline in the program.cs file*/