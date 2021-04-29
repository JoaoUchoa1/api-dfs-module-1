using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains.Models;

namespace WebApplication1.Domains.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; private set; }

        private CategoryResponse(bool sucess, string message, Category category) : base(sucess, message)
        {
            Category = category;
        }

        /// <summary>
        /// Creates a sucess response.
        /// </sumary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>

        public CategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates an error response
        /// </summary>
        /// <param name ="message">Error message</param>
        /// <returns>Response.</returns>

        public CategoryResponse(string message) : this(false, message, null) 
        { }
    }
}
