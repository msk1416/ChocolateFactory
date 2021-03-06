﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SOAP_REST_CLIENT.ProductServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDTO", Namespace="http://schemas.datacontract.org/2004/07/ProductService")]
    [System.SerializableAttribute()]
    public partial class OrderDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ClientIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ShipperIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductServiceReference.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/requestOrder", ReplyAction="http://tempuri.org/IProductService/requestOrderResponse")]
        int requestOrder(int clientId, int productId, int quantity, string date, int shipperId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/acceptOrder", ReplyAction="http://tempuri.org/IProductService/acceptOrderResponse")]
        bool acceptOrder(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/dismissOrder", ReplyAction="http://tempuri.org/IProductService/dismissOrderResponse")]
        bool dismissOrder(int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/deliverStock", ReplyAction="http://tempuri.org/IProductService/deliverStockResponse")]
        bool deliverStock(int productId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/requestStockToHQ", ReplyAction="http://tempuri.org/IProductService/requestStockToHQResponse")]
        int requestStockToHQ(int productId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/getOrders", ReplyAction="http://tempuri.org/IProductService/getOrdersResponse")]
        SOAP_REST_CLIENT.ProductServiceReference.OrderDTO[] getOrders();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : SOAP_REST_CLIENT.ProductServiceReference.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<SOAP_REST_CLIENT.ProductServiceReference.IProductService>, SOAP_REST_CLIENT.ProductServiceReference.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int requestOrder(int clientId, int productId, int quantity, string date, int shipperId) {
            return base.Channel.requestOrder(clientId, productId, quantity, date, shipperId);
        }
        
        public bool acceptOrder(int orderId) {
            return base.Channel.acceptOrder(orderId);
        }
        
        public bool dismissOrder(int orderId) {
            return base.Channel.dismissOrder(orderId);
        }
        
        public bool deliverStock(int productId, int quantity) {
            return base.Channel.deliverStock(productId, quantity);
        }
        
        public int requestStockToHQ(int productId, int quantity) {
            return base.Channel.requestStockToHQ(productId, quantity);
        }
        
        public SOAP_REST_CLIENT.ProductServiceReference.OrderDTO[] getOrders() {
            return base.Channel.getOrders();
        }
    }
}
