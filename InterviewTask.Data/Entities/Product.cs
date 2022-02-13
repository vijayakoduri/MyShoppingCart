using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviewTask.Data.Entities
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }


        // TODO: the rest of the fields

        public double? Price { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }

		public ICollection<ProductGallery> ProductGalleries { get; set; }
	}
}
