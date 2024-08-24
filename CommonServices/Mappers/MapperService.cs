using AutoMapper;

namespace CommonServices.Mappers

{
    public class MapperService
    {
		private static IMapper _mapperInstance;
		public static IMapper MapperInstance
		{
			get
			{
				if (_mapperInstance == null)
				{
					var config = new MapperConfiguration(cfg =>
					{
						cfg.AddProfile<EFToDTOProfile>();
						cfg.AddProfile<DTOToEFProfile>();
					});
					_mapperInstance = config.CreateMapper();
				}
				return _mapperInstance;
			}
		}
	}
}
