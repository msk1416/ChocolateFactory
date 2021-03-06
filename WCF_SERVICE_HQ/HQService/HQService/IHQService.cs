﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HQService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHQService
    {

        [OperationContract]
        int requestStockHQ(int proposedOrderId, String branch, int productId, int quantityAsked);

        [OperationContract]
        int acceptStockRequest(int orderId);

        [OperationContract]
        bool logLocalOrder(int orderId, int localClientId, int productId, String date, int quantity, int localShipperId, bool isAccepted, string justification);

        [OperationContract]
        bool dismissStockOrder(int orderId);

        [OperationContract]
        List<ProductStockDTO> getProductStocks();

        [OperationContract]
        List<PendingStockOrderDTO> getPendingStockOrders();

        [OperationContract]
        List<BranchDTO> getBranches();

        [OperationContract]
        List<OrdersLogDTO> getOrdersLogs();

        [OperationContract]
        List<StockOrderLogDTO> getStockOrderLogs();

        [OperationContract]
        void updateBranchStock(List<int> productsStock);
        
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
