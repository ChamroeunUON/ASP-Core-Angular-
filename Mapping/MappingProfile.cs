using System.Collections.Generic;
using System.Linq;
using ASP_Angular.Controllers.Resources;
using ASP_Angular.Models;
using AutoMapper;

namespace ASP_Angular.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {

            // Map Domain to API Resource
            CreateMap<Make, ModelResource> ();
            CreateMap<Model, ModelResource> ();
            CreateMap<Feature, FeatureResource> ();
            CreateMap<Vehicle, VehicleResource> ()
                .ForMember (vr => vr.Contact, opt => opt.MapFrom (v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
                .ForMember (vr => vr.Features, opt => opt.MapFrom (v => v.Features.Select (vf => vf.FeatureId)));

            // Map API Resource to Domain
            CreateMap<VehicleResource, Vehicle> ()
                .ForMember (v => v.Id, opt => opt.Ignore ())
                .ForMember (v => v.ContactName, opt => opt.MapFrom (vr => vr.Contact.Name))
                .ForMember (v => v.ContactEmail, opt => opt.MapFrom (vr => vr.Contact.Email))
                .ForMember (v => v.ContactPhone, opt => opt.MapFrom (vr => vr.Contact.Phone))
                .ForMember (v => v.Features, opt => opt.Ignore ())
                .AfterMap ((vr, v) => {
                    // remove Unselected features domain
                    // var removeFeatur = new List<VehicleFeature>();
                    // foreach(var f in v.Features)
                    //     if(!vr.Features.Contains(f.FeatureId))
                    //         removeFeatur.Add(f);
                    // foreach(var f in removeFeatur)
                    //     v.Features.Remove(f);

                    // // Add new Features to domain
                    // foreach(var id in vr.Features)
                    //     if(!v.Features.Any(f=>f.FeatureId == id)) // Prevent add Exist items
                    //         v.Features.Add(new VehicleFeature{FeatureId = id});

                    // *****Using Linq******//
                    // remove from domain
                    var removeFeatur = v.Features.Where (f => !vr.Features.Contains (f.FeatureId));
                    foreach (var f in removeFeatur)
                        v.Features.Remove(f);


                    // Add Features to domain
                    var addFeatures = vr.Features
                        .Where (id => !v.Features
                            .Any (f => f.FeatureId == id))
                        .Select (id => new VehicleFeature { FeatureId = id });
                    foreach (var f in addFeatures)
                        v.Features.Add (f);
                });

        }
    }
}