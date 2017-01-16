class BinaryTree

    def self.on(grid)
        grid.each_cell do |cell|
            neighbors = []
            neighbors << cell.south if cell.south
            neighbors << cell.west if cell.west

            neighbor = neighbors.sample

            cell.link(neighbor) if neighbor
        end

        grid
    end
end