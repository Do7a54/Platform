﻿namespace Platform
{
    public class Population
    {
        public static async Task Endpoint(HttpContext context)
        {
            //  string? city = context.Request.RouteValues["city"] as string;
            string city
                     = context.Request.RouteValues["city"] as string ?? "london"; // Using default value Page 337
            int? pop = null;
            //switch ((city ?? "").ToLower())
            switch (city.ToLower())    
            {
                case "london":
                    pop = 8_136_000;
                    break;
                case "paris":
                    pop = 2_141_000;
                    break;
                case "monaco":
                    pop = 39_000;
                    break;
            }
            if (pop.HasValue)
            {
                await context.Response
                .WriteAsync($"City: {city}, Population: {pop}");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}    // Appling Refactoring Middleware into an Endpoint  -- Page 329