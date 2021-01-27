﻿namespace Ingenum.Case.Model.Database
{
    using System;
    public class Task : Entity
    {
        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }
    }
}
