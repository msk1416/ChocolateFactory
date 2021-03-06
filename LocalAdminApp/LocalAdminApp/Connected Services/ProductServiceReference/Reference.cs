﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 15.0.27703.1
// 
namespace LocalAdminApp.ProductServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDTO", Namespace="http://schemas.datacontract.org/2004/07/ProductService")]
    public partial class OrderDTO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int AcceptedField;
        
        private int ClientIDField;
        
        private System.DateTime DateField;
        
        private string JustificationField;
        
        private int OrderIDField;
        
        private int ProductIDField;
        
        private int QuantityField;
        
        private int ShipperIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Accepted {
            get {
                return this.AcceptedField;
            }
            set {
                if ((this.AcceptedField.Equals(value) != true)) {
                    this.AcceptedField = value;
                    this.RaisePropertyChanged("Accepted");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClientID {
            get {
                return this.ClientIDField;
            }
            set {
                if ((this.ClientIDField.Equals(value) != true)) {
                    this.ClientIDField = value;
                    this.RaisePropertyChanged("ClientID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Justification {
            get {
                return this.JustificationField;
            }
            set {
                if ((object.ReferenceEquals(this.JustificationField, value) != true)) {
                    this.JustificationField = value;
                    this.RaisePropertyChanged("Justification");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderID {
            get {
                return this.OrderIDField;
            }
            set {
                if ((this.OrderIDField.Equals(value) != true)) {
                    this.OrderIDField = value;
                    this.RaisePropertyChanged("OrderID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ShipperID {
            get {
                return this.ShipperIDField;
            }
            set {
                if ((this.ShipperIDField.Equals(value) != true)) {
                    this.ShipperIDField = value;
                    this.RaisePropertyChanged("ShipperID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PendingOrderDTO", Namespace="http://schemas.datacontract.org/2004/07/ProductService")]
    public partial class PendingOrderDTO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int ClientIDField;
        
        private System.DateTime DateField;
        
        private int OrderIDField;
        
        private int ProductIDField;
        
        private int QuantityField;
        
        private int ShipperIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClientID {
            get {
                return this.ClientIDField;
            }
            set {
                if ((this.ClientIDField.Equals(value) != true)) {
                    this.ClientIDField = value;
                    this.RaisePropertyChanged("ClientID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderID {
            get {
                return this.OrderIDField;
            }
            set {
                if ((this.OrderIDField.Equals(value) != true)) {
                    this.OrderIDField = value;
                    this.RaisePropertyChanged("OrderID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ShipperID {
            get {
                return this.ShipperIDField;
            }
            set {
                if ((this.ShipperIDField.Equals(value) != true)) {
                    this.ShipperIDField = value;
                    this.RaisePropertyChanged("ShipperID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientDTO", Namespace="http://schemas.datacontract.org/2004/07/ProductService")]
    public partial class ClientDTO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string CityField;
        
        private int ClientIDField;
        
        private string NameField;
        
        private string PreferedFormatField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClientID {
            get {
                return this.ClientIDField;
            }
            set {
                if ((this.ClientIDField.Equals(value) != true)) {
                    this.ClientIDField = value;
                    this.RaisePropertyChanged("ClientID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PreferedFormat {
            get {
                return this.PreferedFormatField;
            }
            set {
                if ((object.ReferenceEquals(this.PreferedFormatField, value) != true)) {
                    this.PreferedFormatField = value;
                    this.RaisePropertyChanged("PreferedFormat");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductDTO", Namespace="http://schemas.datacontract.org/2004/07/ProductService")]
    public partial class ProductDTO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int CostField;
        
        private int PriceField;
        
        private int ProductIDField;
        
        private string ProductNameField;
        
        private int QuantityField;
        
        private int Quantity_UKField;
        
        private string TypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Cost {
            get {
                return this.CostField;
            }
            set {
                if ((this.CostField.Equals(value) != true)) {
                    this.CostField = value;
                    this.RaisePropertyChanged("Cost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity_UK {
            get {
                return this.Quantity_UKField;
            }
            set {
                if ((this.Quantity_UKField.Equals(value) != true)) {
                    this.Quantity_UKField = value;
                    this.RaisePropertyChanged("Quantity_UK");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ShipperDTO", Namespace="http://schemas.datacontract.org/2004/07/ProductService")]
    public partial class ShipperDTO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string CityField;
        
        private int CostPerTonField;
        
        private string NameField;
        
        private int ShipperIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CostPerTon {
            get {
                return this.CostPerTonField;
            }
            set {
                if ((this.CostPerTonField.Equals(value) != true)) {
                    this.CostPerTonField = value;
                    this.RaisePropertyChanged("CostPerTon");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ShipperID {
            get {
                return this.ShipperIDField;
            }
            set {
                if ((this.ShipperIDField.Equals(value) != true)) {
                    this.ShipperIDField = value;
                    this.RaisePropertyChanged("ShipperID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductServiceReference.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/requestOrder", ReplyAction="http://tempuri.org/IProductService/requestOrderResponse")]
        System.Threading.Tasks.Task<int> requestOrderAsync(int clientId, int productId, int quantity, string date, int shipperId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/acceptOrder", ReplyAction="http://tempuri.org/IProductService/acceptOrderResponse")]
        System.Threading.Tasks.Task<bool> acceptOrderAsync(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/dismissOrder", ReplyAction="http://tempuri.org/IProductService/dismissOrderResponse")]
        System.Threading.Tasks.Task<bool> dismissOrderAsync(int orderId, string justification);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/deliverStock", ReplyAction="http://tempuri.org/IProductService/deliverStockResponse")]
        System.Threading.Tasks.Task<bool> deliverStockAsync(int productId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/requestStockToHQ", ReplyAction="http://tempuri.org/IProductService/requestStockToHQResponse")]
        System.Threading.Tasks.Task<int> requestStockToHQAsync(int productId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getOrders", ReplyAction="http://tempuri.org/IProductService/getOrdersResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.OrderDTO>> getOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getPendingOrders", ReplyAction="http://tempuri.org/IProductService/getPendingOrdersResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.PendingOrderDTO>> getPendingOrdersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getOrdersByClient", ReplyAction="http://tempuri.org/IProductService/getOrdersByClientResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.OrderDTO>> getOrdersByClientAsync(int clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getPendingOrdersByClient", ReplyAction="http://tempuri.org/IProductService/getPendingOrdersByClientResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.PendingOrderDTO>> getPendingOrdersByClientAsync(int clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getClients", ReplyAction="http://tempuri.org/IProductService/getClientsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.ClientDTO>> getClientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getProducts", ReplyAction="http://tempuri.org/IProductService/getProductsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.ProductDTO>> getProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getShippers", ReplyAction="http://tempuri.org/IProductService/getShippersResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.ShipperDTO>> getShippersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : LocalAdminApp.ProductServiceReference.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<LocalAdminApp.ProductServiceReference.IProductService>, LocalAdminApp.ProductServiceReference.IProductService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ProductServiceClient() : 
                base(ProductServiceClient.GetDefaultBinding(), ProductServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IProductService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ProductServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ProductServiceClient.GetBindingForEndpoint(endpointConfiguration), ProductServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ProductServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ProductServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ProductServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ProductServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<int> requestOrderAsync(int clientId, int productId, int quantity, string date, int shipperId) {
            return base.Channel.requestOrderAsync(clientId, productId, quantity, date, shipperId);
        }
        
        public System.Threading.Tasks.Task<bool> acceptOrderAsync(int orderId) {
            return base.Channel.acceptOrderAsync(orderId);
        }
        
        public System.Threading.Tasks.Task<bool> dismissOrderAsync(int orderId, string justification) {
            return base.Channel.dismissOrderAsync(orderId, justification);
        }
        
        public System.Threading.Tasks.Task<bool> deliverStockAsync(int productId, int quantity) {
            return base.Channel.deliverStockAsync(productId, quantity);
        }
        
        public System.Threading.Tasks.Task<int> requestStockToHQAsync(int productId, int quantity) {
            return base.Channel.requestStockToHQAsync(productId, quantity);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.OrderDTO>> getOrdersAsync() {
            return base.Channel.getOrdersAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.PendingOrderDTO>> getPendingOrdersAsync() {
            return base.Channel.getPendingOrdersAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.OrderDTO>> getOrdersByClientAsync(int clientId) {
            return base.Channel.getOrdersByClientAsync(clientId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.PendingOrderDTO>> getPendingOrdersByClientAsync(int clientId) {
            return base.Channel.getPendingOrdersByClientAsync(clientId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.ClientDTO>> getClientsAsync() {
            return base.Channel.getClientsAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.ProductDTO>> getProductsAsync() {
            return base.Channel.getProductsAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LocalAdminApp.ProductServiceReference.ShipperDTO>> getShippersAsync() {
            return base.Channel.getShippersAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IProductService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IProductService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/ProductService/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return ProductServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IProductService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return ProductServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IProductService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IProductService,
        }
    }
}
