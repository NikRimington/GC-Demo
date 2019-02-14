//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace GrowCreate.Core.Models
{
	/// <summary>Product</summary>
	[PublishedContentModel("product")]
	public partial class Product : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "product";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Product(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Product, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Display additional currencies: Select additional currencies to display.
		///</summary>
		[ImplementPropertyType("displayAdditionalCurrencies")]
		public IEnumerable<string> DisplayAdditionalCurrencies
		{
			get { return this.GetPropertyValue<IEnumerable<string>>("displayAdditionalCurrencies"); }
		}

		///<summary>
		/// GBP Price
		///</summary>
		[ImplementPropertyType("gbpPrice")]
		public decimal GbpPrice
		{
			get { return this.GetPropertyValue<decimal>("gbpPrice"); }
		}

		///<summary>
		/// Primary Product Photo: Main photo for the product
		///</summary>
		[ImplementPropertyType("primaryProductPhoto")]
		public IPublishedContent PrimaryProductPhoto
		{
			get { return this.GetPropertyValue<IPublishedContent>("primaryProductPhoto"); }
		}

		///<summary>
		/// Summary: Preview summary of the product.
		///</summary>
		[ImplementPropertyType("summary")]
		public string Summary
		{
			get { return this.GetPropertyValue<string>("summary"); }
		}
	}
}