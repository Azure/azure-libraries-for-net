namespace Microsoft.Azure.Management.AppService.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// IP security restriction on an app.
    /// </summary>
    public partial class IpSecurityRestriction
    {
        /// <summary>
        /// Initializes a new instance of the IpSecurityRestriction class.
        /// </summary>
        public IpSecurityRestriction()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IpSecurityRestriction class.
        /// </summary>
        /// <param name="ipAddress">IP address the security restriction is
        /// valid for.
        /// It can be in form of pure ipv4 address (required SubnetMask
        /// property) or
        /// CIDR notation such as ipv4/mask (leading bit match). For CIDR,
        /// SubnetMask property must not be specified.</param>
        /// <param name="subnetMask">Subnet mask for the range of IP addresses
        /// the restriction is valid for.</param>
        /// <param name="action">Allow or Deny access for this IP
        /// range.</param>
        /// <param name="tag">Defines what this IP filter will be used for.
        /// This is to support IP filtering on proxies. Possible values
        /// include: 'Default', 'XffProxy'</param>
        /// <param name="priority">Priority of IP restriction rule.</param>
        /// <param name="name">IP restriction rule name.</param>
        /// <param name="description">IP restriction rule description.</param>
        public IpSecurityRestriction(string ipAddress, string subnetMask = default(string), string action = default(string), int? priority = default(int?), string name = default(string), string description = default(string))
        {
            IpAddress = ipAddress;
            SubnetMask = subnetMask;
            Action = action;
            //Tag = tag;
            Priority = priority;
            Name = name;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets IP address the security restriction is valid for.
        /// It can be in form of pure ipv4 address (required SubnetMask
        /// property) or
        /// CIDR notation such as ipv4/mask (leading bit match). For CIDR,
        /// SubnetMask property must not be specified.
        /// </summary>
        [JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets subnet mask for the range of IP addresses the
        /// restriction is valid for.
        /// </summary>
        [JsonProperty(PropertyName = "subnetMask")]
        public string SubnetMask { get; set; }

        /// <summary>
        /// Gets or sets allow or Deny access for this IP range.
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets defines what this IP filter will be used for. This is
        /// to support IP filtering on proxies. Possible values include:
        /// 'Default', 'XffProxy'
        /// </summary>
        //[JsonProperty(PropertyName = "tag")]
        //public IpFilterTag? Tag { get; set; }

        /// <summary>
        /// Gets or sets priority of IP restriction rule.
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or sets IP restriction rule name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets IP restriction rule description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (IpAddress == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "IpAddress");
            }
        }
    }
}