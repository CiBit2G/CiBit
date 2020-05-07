class Chain:
    def __init__(self, Hash):
        self.currentHash is None
        self.previousHash = Hash
        self.new_block(previous_hash='1', proof=100)

    # a quick verfication that chain's hash is valid till final block
    def valid_chain(self, chain):

    # changes data in block and DB by the consensus
    def resolve_conflicts(self):

    # create final block to add to chain.
    def new_block(self, proof, previous_hash):

    # creates a hash from all the data.
    def hash(block):

    # 
    def proof_of_work(self, last_block):



