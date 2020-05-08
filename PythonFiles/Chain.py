import Block

class Chain:
    def __init__(self, Hash):
        self.currentHash is None
        self.previousHash = Hash
        self.new_block = Block(previousHash=0)

    # a quick verfication that chain's hash is valid till final block
    def valid_chain(self, chain):
        return True
    # changes data in block and DB by the consensus
    def resolve_conflicts(self):
        return self.currentHash
    # create final block to add to chain.
    def new_block(self, proof, previous_hash):
        return proof

    # creates a hash from all the data.
    def hash(block):
        return block

    #
    def proof_of_work(self, last_block):
        return True



