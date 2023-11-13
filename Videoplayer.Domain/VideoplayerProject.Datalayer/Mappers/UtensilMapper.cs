using DomainUtensil = VideoplayerProject.Domain.Models.Utensil;
using DataUtensil = VideoplayerProject.Datalayer.Models.Utensils;

namespace VideoplayerProject.Datalayer.Mappers;

public static class UtensilMapper {
    public static DomainUtensil MapToDomainModel(DataUtensil dataUtensil) {
        var domainUtensil = new DomainUtensil(
            dataUtensil.UtensilName,
            dataUtensil.ImgUrl
        );
        return domainUtensil;
    }

    public static DataUtensil MapToDataModel(DomainUtensil domainUtensil) {
        var dataUtensil = new DataUtensil
        { UtensilID = domainUtensil.Id,
          UtensilName = domainUtensil.Name,
          ImgUrl = domainUtensil.ImgUrl };

        return dataUtensil;
    }
}