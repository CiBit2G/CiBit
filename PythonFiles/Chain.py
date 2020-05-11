from Block import Block

Id = "bank1Test"

class Chain:
    def __init__(self, hush):
        self.currentHash is None
        self.new_block is None
        self.previousHush = hush
        self.BankId = Id

    # a quick verfication that chain's hash is valid till final block
    def valid_chain(self, chain):
        return True

    # changes data in block and DB by the consensus
    def resolve_conflicts(self):
        return self.currentHash

    # create final block to add to chain.
    def new_block(self, proof, previous_hash):
        return proof

    #
    def proof_of_work(self, last_block):
        return True


def main():
    chain =Chain(0)
    chain.new_block()


if __name__ == '__main__':
    main()

