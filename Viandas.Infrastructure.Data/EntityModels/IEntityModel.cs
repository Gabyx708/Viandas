namespace Viandas.Infrastructure.Data.EntityModels
{
    internal interface IEntityModel<Entity, Model>
    {
        Entity MapToEntity();
        Model MapToModel(Entity entity);
    }
}
