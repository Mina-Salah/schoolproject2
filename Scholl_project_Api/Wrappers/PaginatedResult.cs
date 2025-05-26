using System;
using System.Collections.Generic;

namespace Scholl_project_Api.Wrappers
{
    public class PaginatedResult<T>
    {
        // Constructor with only data
        public PaginatedResult(List<T> data)
        {
            Data = data ?? new List<T>();  // If data is not provided, initialize it as an empty list
        }

        // Constructor with all parameters
        public PaginatedResult(List<T> data = null, int currentPage = 1, int pageSize = 10, int totalCount = 0, bool succeeded = true, object meta = null)
        {
            Data = data ?? new List<T>();  // If data is not provided, initialize it as an empty list
            CurrentPage = currentPage;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalCount = totalCount; // Total number of items in the full dataset (used for pagination)
            TotalPages = (int)Math.Ceiling((double)TotalCount / pageSize);  // Calculate TotalPages based on totalCount and pageSize

            // Calculating pagination flags
            HasPreviousPage = currentPage > 1;
            HasNextPage = currentPage < TotalPages;

            // Meta data (if any)
            Meta = meta;

            // Initialize Messages list (can be populated with messages)
            Messages = new List<string>();
        }

        // Data for the current page
        public List<T> Data { get; set; }

        // Current page number
        public int CurrentPage { get; set; }

        // Total number of pages
        public int TotalPages { get; set; }

        // Total number of items in the full dataset (all pages)
        public int TotalCount { get; set; }

        // Optional metadata
        public object Meta { get; set; }

        // Number of items per page
        public int PageSize { get; set; }

        // Indicates if there are previous pages
        public bool HasPreviousPage { get; set; }

        // Indicates if there are next pages
        public bool HasNextPage { get; set; }

        // Messages (e.g., error or info messages)
        public List<string> Messages { get; set; }

        // Status of the pagination request (e.g., whether it succeeded)
        public bool Succeeded { get; set; }
    }
}

/*using System;
using System.Collections.Generic;

namespace Scholl_project_Api.Wrappers
{
    public class PaginatedResult<T>
    {
        // Constructor with only data
        public PaginatedResult(List<T> data)
        {
            Data = data ?? new List<T>();  // If data is not provided, initialize it as an empty list
        }

        // Constructor with all parameters
        public PaginatedResult(List<T> data = default, int currentPage = 1, int pageSize = 10, int totalPage = 0, bool succeeded = true, object meta = null)
        {
            Data = data;  
            CurrentPage = currentPage;
            Succeeded = succeeded;
            PageSize = pageSize;

            //TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Calculating pagination flags
            HasPreviousPage = currentPage > 1;
            HasNextPage = currentPage < TotalPages;

            // Meta data (if any)
            Meta = meta;

            // Initialize Messages list (can be populated with messages)
            Messages = new List<string>();
        }

        // Data for the current page
        public List<T> Data { get; set; }

        // Current page number
        public int CurrentPage { get; set; }

        // Total number of pages
        public int TotalPages { get; set; }

        // Total number of items in the full dataset
        public int TotalCount { get; set; }

        // Optional metadata
        public object Meta { get; set; }

        // Number of items per page
        public int PageSize { get; set; }

        // Indicates if there are previous pages
        public bool HasPreviousPage { get; set; }

        // Indicates if there are next pages
        public bool HasNextPage { get; set; }

        // Messages (e.g., error or info messages)
        public List<string> Messages { get; set; }

        // Status of the pagination request (e.g., whether it succeeded)
        public bool Succeeded { get; set; }
    }
}
*/