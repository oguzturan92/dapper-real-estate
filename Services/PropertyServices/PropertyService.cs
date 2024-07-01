using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperRealEstate.Context;
using DapperRealEstate.Dtos.PropertyDtos;

namespace DapperRealEstate.Services.PropertyServices
{
    public class PropertyService : IPropertyService
    {
        private readonly DbContext _dbContext;
        public PropertyService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePropertyAsync(CreatePropertyDto createPropertyDto, int[] selectTags)
        {
            string query = "Insert Into Property (PropertyTitle, PropertySubTitle, PropertyDescription, PropertyAddress, PropertyEmbed, PropertyDate, PropertyPrice, PropertySlider, PropertySliderImage, PropertyHome, PropertySell, AgentId, CategoryId, LocationId, PropertyTypeId) values (@propertyTitle, @propertySubTitle, @propertyDescription, @propertyAddress, @propertyEmbed, @propertyDate, @propertyPrice, @propertySlider, @propertySliderImage, @propertyHome, @propertySell, @agentId, @categoryId, @locationId, @propertyTypeId)";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyTitle", createPropertyDto.PropertyTitle);
            parameters.Add("@propertySubTitle", createPropertyDto.PropertySubTitle);
            parameters.Add("@propertyDescription", createPropertyDto.PropertyDescription);
            parameters.Add("@propertyAddress", createPropertyDto.PropertyAddress);
            parameters.Add("@propertyEmbed", createPropertyDto.PropertyEmbed);
            parameters.Add("@propertyDate", createPropertyDto.PropertyDate);
            parameters.Add("@propertyPrice", createPropertyDto.PropertyPrice);
            parameters.Add("@propertySlider", createPropertyDto.PropertySlider);
            parameters.Add("@propertySliderImage", createPropertyDto.PropertySliderImage);
            parameters.Add("@propertyHome", createPropertyDto.PropertyHome);
            parameters.Add("@propertySell", createPropertyDto.PropertySell);
            parameters.Add("@agentId", createPropertyDto.AgentId);
            parameters.Add("@categoryId", createPropertyDto.CategoryId);
            parameters.Add("@locationId", createPropertyDto.LocationId);
            parameters.Add("@propertyTypeId", createPropertyDto.PropertyTypeId);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);

            string query2 = "SELECT IDENT_CURRENT('PROPERTY')";
            var propertyId = await connection.QueryFirstOrDefaultAsync<int>(query2);

            foreach (var tagId in selectTags)
            {
                string query3 = "Insert Into PropertyTag (PropertyId, TagId) values (@propertyId, @tagId)";
                var parameters3 = new DynamicParameters();
                parameters3.Add("@propertyId", propertyId);
                parameters3.Add("@tagId", tagId);
                await connection.ExecuteAsync(query3, parameters3);
            }
        }

        public async Task DeletePropertyAsync(int id)
        {
            string query2 = "Delete From PropertyTag Where PropertyId=@propertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query2, parameters);

            string query3 = "Delete From Image Where PropertyId=@propertyId";
            await connection.ExecuteAsync(query3, parameters);

            string query = "Delete From Property Where PropertyId=@propertyId";
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<GetByIdPropertyDto> GetPropertyAsync(int id)
        {
            // string query = "Select * From Property Where PropertyId=@propertyId";
            // string query2 = "Select p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyDescription, p.PropertyAddress, p.PropertyEmbed, p.PropertyDate, p.PropertyPrice, p.PropertySlider, p.PropertySliderImage, p.PropertyHome, p.PropertySell, a.AgentId, a.AgentFullname, c.CategoryId, c.CategoryName, l.LocationId, l.LocationName, ppt.PropertyTypeId, ppt.PropertyTypeName, t.TagId, t.TagName  From Property p Inner Join Agent a On p.AgentId = a.AgentId Inner Join Category c On p.CategoryId = c.CategoryId Inner Join Location l On p.LocationId = l.LocationId Inner Join PropertyType ppt On p.PropertyTypeId = ppt.PropertyTypeId Join PropertyTag pt On p.PropertyId = pt.PropertyId Join Tag t on pt.TagId = t.TagId Where p.PropertyId = @propertyId";
            string query2 = "Select p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyDescription, p.PropertyAddress, p.PropertyEmbed, p.PropertyDate, p.PropertyPrice, p.PropertySlider, p.PropertySliderImage, p.PropertyHome, p.PropertySell, a.AgentId, a.AgentFullname, c.CategoryId, c.CategoryName, l.LocationId, l.LocationName, ppt.PropertyTypeId, ppt.PropertyTypeName, STRING_AGG(t.TagName, ' ') AS TagNames, STRING_AGG(t.TagId, ' ') AS TagIds, COUNT(t.TagId) AS TagCount  From Property p Inner Join Agent a On p.AgentId = a.AgentId Inner Join Category c On p.CategoryId = c.CategoryId Inner Join Location l On p.LocationId = l.LocationId Inner Join PropertyType ppt On p.PropertyTypeId = ppt.PropertyTypeId Left Join PropertyTag pt On p.PropertyId = pt.PropertyId Left Join Tag t on pt.TagId = t.TagId Group By p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyDescription, p.PropertyAddress, p.PropertyEmbed, p.PropertyDate, p.PropertyPrice, p.PropertySlider, p.PropertySliderImage, p.PropertyHome, p.PropertySell, a.AgentId, a.AgentFullname, c.CategoryId, c.CategoryName, l.LocationId, l.LocationName, ppt.PropertyTypeId, ppt.PropertyTypeName Having p.PropertyId = @propertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdPropertyDto>(query2, parameters);
            return values;
        }

        public async Task<GetDetailPropertyDto> GetDetailPropertyAsync(int id)
        {
            string query = "Select p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyDescription, p.PropertyAddress, p.PropertyEmbed, p.PropertyDate, p.PropertyPrice, p.PropertySlider, p.PropertySliderImage, p.PropertyHome, p.PropertySell, a.AgentId, a.AgentFullname, c.CategoryId, c.CategoryName, l.LocationId, l.LocationName, ppt.PropertyTypeId, ppt.PropertyTypeName, STRING_AGG(t.TagName, ' ') AS TagNames, STRING_AGG(t.TagId, ' ') AS TagIds, COUNT(t.TagId) AS TagCount  From Property p Inner Join Agent a On p.AgentId = a.AgentId Inner Join Category c On p.CategoryId = c.CategoryId Inner Join Location l On p.LocationId = l.LocationId Inner Join PropertyType ppt On p.PropertyTypeId = ppt.PropertyTypeId Left Join PropertyTag pt On p.PropertyId = pt.PropertyId Left Join Tag t on pt.TagId = t.TagId Group By p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyDescription, p.PropertyAddress, p.PropertyEmbed, p.PropertyDate, p.PropertyPrice, p.PropertySlider, p.PropertySliderImage, p.PropertyHome, p.PropertySell, a.AgentId, a.AgentFullname, c.CategoryId, c.CategoryName, l.LocationId, l.LocationName, ppt.PropertyTypeId, ppt.PropertyTypeName Having p.PropertyId = @propertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetDetailPropertyDto>(query, parameters);
            return values;
        }

        public async Task<List<ResultPropertyDto>> GetAllPropertyAsync()
        {
            string query = "Select PropertyId, PropertyTitle, PropertyDate, AgentFullname, CategoryName, LocationName From Property p Inner Join Category c On p.CategoryId=c.CategoryId Inner Join Agent a On p.AgentId=a.AgentId Inner Join Location l On p.LocationId=l.LocationId";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultPropertyDto>(query);
            return values.ToList();
        }

        public async Task UpdatePropertyAsync(UpdatePropertyDto updatePropertyDto, int[] selectTags)
        {
            string query = "Update Property Set PropertyTitle=@propertyTitle, PropertySubTitle=@propertySubTitle, PropertyDescription=@propertyDescription, PropertyAddress=@propertyAddress, PropertyEmbed=@propertyEmbed, PropertyDate=@propertyDate, PropertyPrice=@propertyPrice, PropertySlider=@propertySlider, PropertySliderImage=@propertySliderImage, PropertyHome=@propertyHome, PropertySell=@propertySell, AgentId=@agentId, CategoryId=@categoryId, LocationId=@locationId, PropertyTypeId=@propertyTypeId where PropertyId=@propertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", updatePropertyDto.PropertyId);
            parameters.Add("@propertyTitle", updatePropertyDto.PropertyTitle);
            parameters.Add("@propertySubTitle", updatePropertyDto.PropertySubTitle);
            parameters.Add("@propertyDescription", updatePropertyDto.PropertyDescription);
            parameters.Add("@propertyAddress", updatePropertyDto.PropertyAddress);
            parameters.Add("@propertyEmbed", updatePropertyDto.PropertyEmbed);
            parameters.Add("@propertyDate", updatePropertyDto.PropertyDate);
            parameters.Add("@propertyPrice", updatePropertyDto.PropertyPrice);
            parameters.Add("@propertySlider", updatePropertyDto.PropertySlider);
            parameters.Add("@propertySliderImage", updatePropertyDto.PropertySliderImage);
            parameters.Add("@propertyHome", updatePropertyDto.PropertyHome);
            parameters.Add("@propertySell", updatePropertyDto.PropertySell);
            parameters.Add("@agentId", updatePropertyDto.AgentId);
            parameters.Add("@categoryId", updatePropertyDto.CategoryId);
            parameters.Add("@locationId", updatePropertyDto.LocationId);
            parameters.Add("@propertyTypeId", updatePropertyDto.PropertyTypeId);

            // Mevcutları siler -----------------------------------------------------
            string query2 = "Delete From PropertyTag Where PropertyId=@propertyId";
            var parameters2 = new DynamicParameters();
            parameters2.Add("@propertyId", updatePropertyDto.PropertyId);
            var connection2 = _dbContext.CreateConnection();
            await connection2.ExecuteAsync(query2, parameters2);
            // ----------------------------------------------------------------------

            foreach (var tagId in selectTags)
            {
                string query3 = "Insert Into PropertyTag (PropertyId, TagId) values (@propertyId, @tagId)";
                var parameters3 = new DynamicParameters();
                parameters3.Add("@propertyId", updatePropertyDto.PropertyId);
                parameters3.Add("@tagId", tagId);
                await connection2.ExecuteAsync(query3, parameters3);
            }

            var connection = _dbContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<int> GetPropertyCount()
        {
            string query = "Select Count(*) From Property";
            var connection = _dbContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }
    
        public async Task<List<ResultSliderPropertyDto>> GetSliderTruePropertyAsync()
        {
            string query = "Select PropertyId, PropertyTitle, PropertySubTitle, PropertyAddress, PropertyPrice, PropertySliderImage, LocationName From Property p Inner Join Location l On p.LocationId=l.LocationId Where p.PropertySlider='True'";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultSliderPropertyDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultHomePropertyDto>> GetRecentPropertyAsync()
        {
            string query = "Select p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, c.CategoryName, l.LocationName, ppt.PropertyTypeName, STRING_AGG(i.ImageName, ' ') AS ImageName From Property p Inner Join Category c On p.CategoryId=c.CategoryId Inner Join PropertyType ppt On p.PropertyTypeId=ppt.PropertyTypeId Inner Join Location l On p.LocationId=l.LocationId Left Join Image i On p.PropertyId=i.PropertyId Group By p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, c.CategoryName, l.LocationName, ppt.PropertyTypeName Having p.PropertyHome='True'";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultHomePropertyDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultHomePropertyDto>> GetLast4PropertyAsync()
        {
            string query = "Select Top 4 p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, c.CategoryName, l.LocationName, ppt.PropertyTypeName, STRING_AGG(i.ImageName, ' ') AS ImageName From Property p Inner Join Category c On p.CategoryId=c.CategoryId Inner Join PropertyType ppt On p.PropertyTypeId=ppt.PropertyTypeId Inner Join Location l On p.LocationId=l.LocationId Left Join Image i On p.PropertyId=i.PropertyId Group By p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, c.CategoryName, l.LocationName, ppt.PropertyTypeName  Order By PropertyId Desc";
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultHomePropertyDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultHomePropertyDto>> GetListPropertyAsync(int skip, int take)
        {
            string query = "Select p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, c.CategoryName, l.LocationName, ppt.PropertyTypeName, STRING_AGG(i.ImageName, ' ') AS ImageName From Property p Inner Join Category c On p.CategoryId=c.CategoryId Inner Join PropertyType ppt On p.PropertyTypeId=ppt.PropertyTypeId Inner Join Location l On p.LocationId=l.LocationId Left Join Image i On p.PropertyId=i.PropertyId Group By p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, c.CategoryName, l.LocationName, ppt.PropertyTypeName ORDER BY p.PropertyId OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY";
            var parameters = new DynamicParameters();
            parameters.Add("@skip", skip);
            parameters.Add("@take", take);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultHomePropertyDto>(query, parameters);
            return values.ToList();
        }

        public async Task<GetDetailImagePropertyDto> GetDetailImagePropertyAsync(int id)
        {
            string query = "Select p.PropertyId, STRING_AGG(i.ImageName, ' ') AS ImageName, COUNT(i.ImageId) AS ImageCount From Property p Left Join Image i On p.PropertyId=i.PropertyId Group By p.PropertyId Having p.PropertyId = @propertyId";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetDetailImagePropertyDto>(query, parameters);
            return values;
        }

        public async Task<float> GetPropertyMaxPrice()
        {
            string query = "SELECT TOP 1 p.PropertyPrice FROM Property p ORDER BY p.PropertyPrice DESC";
            var connection = _dbContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<float> GetPropertyMinPrice()
        {
            string query = "SELECT TOP 1 p.PropertyPrice FROM Property p ORDER BY p.PropertyPrice";
            var connection = _dbContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task<List<ResultHomePropertyDto>> GetListSearchPropertyAsync(string q, int location, float minPrice, float maxPrice)
        {
            string query = "";
            if (location > 0)
            {
                query = "Select p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, p.LocationId, c.CategoryName, l.LocationName, ppt.PropertyTypeName, STRING_AGG(i.ImageName, ' ') AS ImageName From Property p Inner Join Category c On p.CategoryId=c.CategoryId Inner Join PropertyType ppt On p.PropertyTypeId=ppt.PropertyTypeId Inner Join Location l On p.LocationId=l.LocationId Left Join Image i On p.PropertyId=i.PropertyId Group By p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, p.LocationId, c.CategoryName, l.LocationName, ppt.PropertyTypeName Having p.PropertyTitle LIKE '%' + @q + '%' AND (p.LocationId = @location AND (p.PropertyPrice >= @minPrice AND p.PropertyPrice <= @maxPrice))";
            } else
            {
                query = "Select p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, p.LocationId, c.CategoryName, l.LocationName, ppt.PropertyTypeName, STRING_AGG(i.ImageName, ' ') AS ImageName From Property p Inner Join Category c On p.CategoryId=c.CategoryId Inner Join PropertyType ppt On p.PropertyTypeId=ppt.PropertyTypeId Inner Join Location l On p.LocationId=l.LocationId Left Join Image i On p.PropertyId=i.PropertyId Group By p.PropertyId, p.PropertyTitle, p.PropertySubTitle, p.PropertyPrice, p.PropertySell, p.PropertyHome, p.LocationId, c.CategoryName, l.LocationName, ppt.PropertyTypeName Having p.PropertyTitle LIKE '%' + @q + '%' AND (p.PropertyPrice >= @minPrice AND p.PropertyPrice <= @maxPrice)";
            }


            var parameters = new DynamicParameters();
            parameters.Add("@q", q);
            parameters.Add("@location", location);
            parameters.Add("@minPrice", minPrice);
            parameters.Add("@maxPrice", maxPrice);
            var connection = _dbContext.CreateConnection();
            var values = await connection.QueryAsync<ResultHomePropertyDto>(query, parameters);
            return values.ToList();
        }
    }
}