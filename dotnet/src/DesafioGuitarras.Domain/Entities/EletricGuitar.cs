﻿using System;

namespace DesafioGuitarras.Domain.Entities
{
    public class EletricGuitar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime InsertDate { get; set; }
        public string ImageUrl { get; set; }
        public string Sku
        {
            get => $"{Id}_{Name.Replace(' ', '_').ToLower()}"; 
            set { }
        }
    }
}