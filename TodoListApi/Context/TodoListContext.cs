﻿using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Context
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> dbContext) : base(dbContext) {}

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
