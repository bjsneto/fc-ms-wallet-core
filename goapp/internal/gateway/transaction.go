package gateway

import "github.com/bjsneto/fc-ms-wallet-core/internal/entity"

type TransactionGateway interface {
	Create(transaction *entity.Transaction) error
}
