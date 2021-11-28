﻿using System;

namespace Employees.Core.Dtos
{
    public class BaseDto<T>
    {
        /// <summary>
        /// The primary key.
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// The creation datetime.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Logical delete, if true don't show it.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
