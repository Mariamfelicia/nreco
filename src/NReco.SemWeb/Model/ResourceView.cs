﻿#region License
/*
 * NReco library (http://nreco.googlecode.com/)
 * Copyright 2008,2009 Vitaliy Fedorchenko
 * Distributed under the LGPL licence
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SemWeb;
using NReco.SemWeb;

namespace NReco.SemWeb.Model {
	
	/// <summary>
	/// RDF Resource 'view'
	/// </summary>
	public class ResourceView {
		IList<Statement> Statements = null;
		SelectableSource Source;
		IDictionary<Entity, PropertyView> PropertiesHash = null;
		
		public Entity Uid { get; protected set; }
		
		public int MaxProperties { get; set; }
		
		string _Label = null;
		
		/// <summary>
		/// Get or set resource label
		/// </summary>
		/// <remarks>Label is extracted from resource properties if not speficied explicitely.</remarks>
		public string Label {
			get {
				if (_Label!=null)
					return _Label;
				var prop = this[NS.Rdfs.labelEntity];
				if (prop.HasValue)
					return prop.Value.ToString();
				return null;
			}
			set {
				_Label = value;
			}
		}
		
		ResourceView _Type;
		/// <summary>
		/// Get or set resource RDF type
		/// </summary>
		public ResourceView Type {
			get {
				if (_Type != null)
					return _Type;			
				var prop = this[NS.Rdf.typeEntity];
				if (prop.HasReference)
					return prop.Reference;
				return null;
			}
			set {
				_Type = value;
			}
		}

		public ICollection<PropertyView> Properties {
			get {
				EnsureData();
				return PropertiesHash.Values;
			}
		}

		public PropertyView this[Entity prop] {
			get {
				EnsureData();
				return PropertiesHash.ContainsKey(prop) ? 
					PropertiesHash[prop] :
					new PropertyView( new ResourceView(prop,Source), null,null);
			}
		}

		public PropertyView this[ResourceView prop] {
			get {
				return this[prop.Uid];
			}
		}

		public ResourceView(string resourceUri, SelectableSource source) {
			Uid = new Entity(resourceUri);
			Source = source;
			MaxProperties = 1000;
		}

		public ResourceView(Entity resourceEntity, SelectableSource source) {
			Uid = resourceEntity;
			Source = source;
			MaxProperties = 1000;
		}


		protected void EnsureData() {
			if (Statements == null)
				Statements = Source.SelectList(new Statement(Uid, null, null), true);

			PropertiesHash = new Dictionary<Entity, PropertyView>();
			var groups = new Dictionary<Entity, IList<Resource>>();

			// collect and group-by-property
			foreach (var st in Statements) {
				if (!groups.ContainsKey(st.Predicate))
					groups[st.Predicate] = new List<Resource>();
				if (!groups[st.Predicate].Contains(st.Object))
					groups[st.Predicate].Add(st.Object);
			}

			foreach (var group in groups) {
				var valueList = new List<object>();
				var refList = new List<ResourceView>();
				var propertyView = new ResourceView(group.Key, Source);
				foreach (var res in group.Value) {
					if (res is Literal)
						valueList.Add(GetObject((Literal)res));
					else if (res is Entity)
						refList.Add(new ResourceView((Entity)res, Source));
				}
				var prop = new PropertyView(propertyView, valueList, refList);
				PropertiesHash[propertyView.Uid] = prop;
			}
		}

		protected object GetObject(Literal lit) {
			//TDB
			return lit.Value;
		}

		public bool IsProperty {
			get { return Source.Contains(new Statement(Uid, NS.Rdf.typeEntity, NS.Rdf.PropertyEntity)); }
		}

		public bool IsClass {
			get { return Source.Contains(new Statement(Uid, NS.Rdf.typeEntity, NS.Rdfs.ClassEntity)); }
		}

		public override int GetHashCode() {
			return Uid.GetHashCode();
		}

		public override bool Equals(object obj) {
			if (obj is ResourceView)
				return Uid.Equals(((ResourceView)obj).Uid);
			return base.Equals(obj);
		}

	}
}
