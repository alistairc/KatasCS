namespace AntsWorld;

interface IProjector<in TWorld>
{
    string[] Project(TWorld world);
}