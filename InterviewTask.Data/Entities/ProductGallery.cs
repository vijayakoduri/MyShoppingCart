using System.ComponentModel.DataAnnotations;

namespace InterviewTask.Data.Entities
{
	public class ProductGallery
	{
		[Key]
		public int Id { get; set; }
        public int ProductiD { get; internal set; }
        public string Name { get; internal set; }
        public string Url { get; internal set; }

        // TODO: complete the fields
    }
}
