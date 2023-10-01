namespace OstringsAdmin.Mapper
{
    public static class GeneralMapper
    {
        public static Dto.Category MapCategory(Data.Models.Category category)
        {
            return new Dto.Category()
            {
                Id = category.Id,
                Description = category.Description,
                Name = category.Name,
            };
        }

		public static Dto.Provider MapProvider(Data.Models.Provider provider)
		{
			return new Dto.Provider()
			{
				Id = provider.Id,
				Name = provider.Name,
			};
		}
	}
}
