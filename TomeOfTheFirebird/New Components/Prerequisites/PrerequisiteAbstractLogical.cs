using Kingmaker.Blueprints.Classes.Prerequisites;
using System.Collections.Generic;

namespace TomeOfTheFirebird.NewComponents.Prerequisites
{
    public abstract class PrerequisiteAbstractLogical : Prerequisite
    {


        public List<Prerequisite> componentPrequisites = new List<Prerequisite>();


        public void AddPrequisiteToList(Prerequisite p)
        {
            componentPrequisites.Add(p);
            p.OwnerBlueprint = this.OwnerBlueprint;
        }

    }
}
